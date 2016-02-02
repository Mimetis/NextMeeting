using NextMeeting.Models;
using NextMeeting.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace NextMeeting.Common
{
    public class TaskHelper
    {
        public const string TimeTriggerEntryPoint = "NextMeeting.Tasks.TileTask";

        public const string TimeTriggeredTaskName = "TimeTriggeredTask";
        public static string TimeTriggeredTaskProgress = "";
        public static bool TimeTriggeredTaskRegistered = false;

        private static TaskHelper current;

        public static TaskHelper Current
        {
            get
            {
                if (current == null)
                    current = new TaskHelper();

                return current;
            }
        }

        public bool IsRegister { get; set; }

        /// <summary>
        /// Register task for every 15 minutes if Internet is available
        /// </summary>
        /// <returns></returns>
        public async Task RegisterTileBackgroundTask()
        {

            CheckTileBrackgroundTask();

            if (IsRegister)
                return;

            var backgroundTaskRegistration = await RegisterBackgroundTask(
                                                    TimeTriggerEntryPoint,
                                                    TimeTriggeredTaskName,
                                                    new TimeTrigger(15, false),
                                                    new SystemCondition(SystemConditionType.InternetAvailable));

            AttachProgressAndCompletedHandlers(backgroundTaskRegistration);
        }
        private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
        {
            task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
            task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
        }

        /// <summary>
        /// Handle background task progress.
        /// </summary>
        /// <param name="task">The task that is reporting progress.</param>
        /// <param name="e">Arguments of the progress report.</param>
        private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
        {
            var progress = "Progress: " + args.Progress + "%";
            Debug.WriteLine(progress);
        }

        /// <summary>
        /// Handle background task completion.
        /// </summary>
        /// <param name="task">The task that is reporting completion.</param>
        /// <param name="e">Arguments of the completion report.</param>
        private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            Debug.WriteLine("Completed." + args.InstanceId);
        }


        public void CheckTileBrackgroundTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == TimeTriggeredTaskName)
                {
                    AttachProgressAndCompletedHandlers(task.Value);
                    this.IsRegister = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Register a background task with the specified taskEntryPoint, name, trigger,
        /// and condition (optional).
        /// </summary>
        /// <param name="taskEntryPoint">Task entry point for the background task.</param>
        /// <param name="name">A name for the background task.</param>
        /// <param name="trigger">The trigger for the background task.</param>
        /// <param name="condition">An optional conditional event that must be true for the task to fire.</param>
        private async Task<BackgroundTaskRegistration> RegisterBackgroundTask(String taskEntryPoint, String name, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {

            if (TaskRequiresBackgroundAccess(name))
                await BackgroundExecutionManager.RequestAccessAsync();

            var builder = new BackgroundTaskBuilder();

            builder.Name = name;
            builder.TaskEntryPoint = taskEntryPoint;
            builder.SetTrigger(trigger);

            if (condition != null)
            {
                builder.AddCondition(condition);

                //
                // If the condition changes while the background task is executing then it will
                // be canceled.
                //
                builder.CancelOnConditionLoss = true;
            }

            BackgroundTaskRegistration task = builder.Register();

            this.IsRegister = true;

            //
            // Remove previous completion status from local settings.
            //
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values.Remove(name);

            return task;
        }

        /// <summary>
        /// Unregister background tasks with specified name.
        /// </summary>
        /// <param name="name">Name of the background task to unregister.</param>
        public void UnregisterBackgroundTasks(string name)
        {
            //
            // Loop through all background tasks and unregister any with SampleBackgroundTaskName or
            // SampleBackgroundTaskWithConditionName.
            //
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == name)
                {
                    cur.Value.Unregister(true);
                }
            }

            this.IsRegister = false;
        }



        /// <summary>
        /// Get the registration / completion status of the background task with
        /// given name.
        /// </summary>
        /// <param name="name">Name of background task to retreive registration status.</param>
        public static String GetBackgroundTaskStatus(String name)
        {
            var registered = false;
            switch (name)
            {

                case TimeTriggeredTaskName:
                    registered = TimeTriggeredTaskRegistered;
                    break;
            }

            var status = registered ? "Registered" : "Unregistered";

            var settings = ApplicationData.Current.LocalSettings;
            if (settings.Values.ContainsKey(name))
                status += " - " + settings.Values[name].ToString();

            return status;
        }

        /// <summary>
        /// Determine if task with given name requires background access.
        /// </summary>
        /// <param name="name">Name of background task to query background access requirement.</param>
        public static bool TaskRequiresBackgroundAccess(String name)
        {
            if (name == TimeTriggeredTaskName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task SendNotification()
        {
            var etm = await TileTask.GetNextEvent();

            if (etm != null)
                TileHelper.Current.SendEventTileNotification(etm);
        }
    }
}
