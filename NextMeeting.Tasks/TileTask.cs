using Newtonsoft.Json.Linq;
using NextMeeting.Common;
using NextMeeting.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Storage;
using Windows.System.Threading;

namespace NextMeeting.Tasks
{
    public sealed class TileTask : IBackgroundTask
    {

        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        volatile bool _cancelRequested = false;
        BackgroundTaskDeferral _deferral = null;
        ThreadPoolTimer _periodicTimer = null;
        uint _progress = 0;
        IBackgroundTaskInstance _taskInstance = null;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

            //
            // Query BackgroundWorkCost
            // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
            // of work in the background task and return immediately.
            //
            var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values["BackgroundWorkCost"] = cost.ToString();

            //
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            //
            _deferral = taskInstance.GetDeferral();


            var nextEvent = await GetNextEvent();


            if (nextEvent != null)
                TileHelper.Current.SendEventTileNotification(nextEvent);

            //
            // Associate a cancellation handler with the background task.
            //
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            _taskInstance = taskInstance;

            _deferral.Complete();

            //_periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback),
            //    TimeSpan.FromSeconds(1));
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            //
            // Indicate that the background task is canceled.
            //
            _cancelRequested = true;
            _cancelReason = reason;

            Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
        }

        //
        // Simulate the background task activity.
        //
        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            if ((_cancelRequested == false) && (_progress < 100))
            {
                _progress += 10;
                _taskInstance.Progress = _progress;
            }
            else
            {
                _periodicTimer.Cancel();

                var settings = ApplicationData.Current.LocalSettings;
                var key = _taskInstance.Task.Name;

                //
                // Write to LocalSettings to indicate that this background task ran.
                //
                settings.Values[key] = (_progress < 100) ? "Canceled with reason: " + _cancelReason.ToString() : "Completed";
                Debug.WriteLine("Background " + _taskInstance.Task.Name + settings.Values[key]);

                //
                // Indicate that the background task has completed.
                //
                _deferral.Complete();
            }
        }

        public static IAsyncOperation<EventTileModel> GetNextEvent()
        {
            return InternalGetNextEvent().AsAsyncOperation<EventTileModel>();
        }

        private static async Task<EventTileModel> InternalGetNextEvent()
        {
            var events = new List<EventTileModel>();

            try
            {

                var start = DateTime.UtcNow.ToString("o");
                var end = DateTime.UtcNow.AddDays(1).ToString("o");

                using (HttpClient client = new HttpClient())
                {
                    var token = await AuthenticationHelper.TryAuthenticateSilentlyAsync();

                    if (string.IsNullOrEmpty(token))
                        return null;

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    string query = String.Format("?startDateTime={0}&endDateTime={1}", start, end);
                    // Endpoint for the current user's events
                    Uri usersEndpoint = new Uri(AuthenticationHelper.GraphEndpointId + "me/calendarView" + query);

                    using (HttpResponseMessage response = await client.GetAsync(usersEndpoint))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();

                            var jResult = JObject.Parse(responseContent);

                            foreach (JObject jsonEvent in jResult["value"])
                            {
                                EventTileModel evm = new EventTileModel();
                                evm.OrganizerName = jsonEvent["organizer"]["emailAddress"]["name"].Value<string>();
                                evm.OrganizerMail = jsonEvent["organizer"]["emailAddress"]["address"].Value<string>();
                                evm.Subject = jsonEvent["subject"].Value<string>();
                                var startingDate = DateTime.Parse(jsonEvent["start"]["dateTime"].Value<string>()).ToLocalTime();
                                evm.Start = startingDate;
                                var hourStartingDate = startingDate.Hour < 10 ? "0" + startingDate.Hour.ToString() : startingDate.Hour.ToString();
                                var minStartingDate = startingDate.Minute < 10 ? "0" + startingDate.Minute.ToString() : startingDate.Minute.ToString();
                                var startingHourDate = string.Format("{0}:{1}", hourStartingDate, minStartingDate);
                                var endDate = DateTime.Parse(jsonEvent["end"]["dateTime"].Value<string>()).ToLocalTime();
                                evm.End = endDate;
                                var hourEndDate = endDate.Hour < 10 ? "0" + endDate.Hour.ToString() : endDate.Hour.ToString();
                                var minEndDate = endDate.Minute < 10 ? "0" + endDate.Minute.ToString() : endDate.Minute.ToString();
                                var endHourDate = string.Format("{0}:{1}", hourEndDate, minEndDate);
                                evm.BodyPreview = jsonEvent["bodyPreview"].Value<string>();
                                evm.IsAllDay = jsonEvent["isAllDay"].Value<bool>();

                                evm.TimeDelta = evm.IsAllDay ? "All day event" : startingHourDate + "-" + endHourDate;

                                events.Add(evm);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            if (events == null)
                return null;


            events = events.Where(ev => ev.Start.LocalDateTime > DateTime.Now.ToLocalTime()).ToList();
            // ordering all events
            var gEvents = events.GroupBy(ev => ev.Start).ToList();
            // get day events
            var gEventsOrdered = gEvents.OrderBy(g => g.Key).ToList();

            if (gEventsOrdered.Count <= 0)
                return null;

            var evg = gEventsOrdered[0];
            var lst = evg.OrderBy(ev => ev.Start.DateTime).OrderBy(ev => ev.IsAllDay).ToList();
            var evtzero = lst[0];

            var spUsers = await SharePointSearchHelper.SPGetUsers(new[] { evtzero.OrganizerMail });

            if (spUsers == null)
                return null;
            
            var user = spUsers[0];

            var internalItems = await SharePointSearchHelper.SPGetSharedFilesBeetweenUserAndMe(user.DocId);

            var graph = AuthenticationHelper.GetGraphService();

            var imageUri = await TileHelper.Current.GetPhotoUri(user.UserName);

            if (imageUri != null)
                evtzero.OrganizerImageAbsoluteUri = imageUri.AbsoluteUri;

            foreach (var item in internalItems)
            {
                DriveItemTileModel ditm = new DriveItemTileModel();

                FileInfo fi = new FileInfo(item.Filename);

                var fileExtension = fi.Extension;
                var fileExtensionIconUri = TileHelper.Current.GetImageExtensionsUri(fi.Extension);

                ditm.IconAbsoluteUri = fileExtensionIconUri.AbsoluteUri;
                ditm.Title = item.Title;

                evtzero.Items.Add(ditm);
            }

            return evtzero;
        }
    }
}
