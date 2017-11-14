using Autofac;
using NextMeeting.Navigation;
using NextMeeting.Services;
using NextMeeting.ViewModels;
using NextMeeting.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NextMeeting.Helpers
{

    /// <summary>
    /// Class helpe for managing DI 
    /// </summary>
    public class ContainerHelper
    {
        private static ContainerHelper instance;

        public static ContainerHelper Current = instance ?? (instance = new ContainerHelper());

        /// <summary>
        /// Association between a view and a view model
        /// </summary>
        private Dictionary<Type, (Type, Action<object, object, object>)> dictionary = new Dictionary<Type, (Type, Action<object, object, object>)>();


        private Dictionary<Type, Type> associatedViewModelTypes = new Dictionary<Type, Type>();


        /// <summary>
        /// Access to the underlying autofac builder
        /// </summary>
        //public ContainerBuilder Builder { get; }

        /// <summary>
        /// Get the container
        /// </summary>
        public IContainer Container { get; set; }

        public ContainerHelper()
        {
        }


        /// <summary>
        /// Register all types we need in the application
        /// </summary>
        /// <param name="frame"></param>
        public void RegisterTypes(Frame frame)
        {
            //// Using a frame adapter to be able to inject it through DI
            //FrameAdapter adapter = new FrameAdapter(frame);

            var builder = new ContainerBuilder();


            builder.RegisterInstance(frame);

            //// Register the FrameAdapter object
            //builder.RegisterInstance(adapter).As<IFrameAdapter>();

            // Register auth provider
            builder.RegisterType<AuthenticationProvider>().As<IAuthenticationProvider2>();

            // Register graph service
            builder.RegisterType<GraphProvider>().As<IGraphProvider>();

            // Register user service
            builder.RegisterType<UserProvider>().As<IUserProvider>();

            // Register a Navigation Service single instance
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            // Singleton ?
            builder.RegisterType<EventsViewModel>().SingleInstance();
            builder.RegisterType<SearchesViewModel>().SingleInstance();
            builder.RegisterType<EventDetailsViewModel>().SingleInstance();
            builder.RegisterType<ProfileDetailsViewModel>().SingleInstance();
            builder.RegisterType<LogoutViewModel>().SingleInstance();

            this.Container = builder.Build();
        }

        /// <summary>
        /// Get the ViewModel associated with the current page type
        /// </summary>
        public IViewModelNavigable GetPageViewModel(Type sourcePageType)
        {

            Type viewModelType = null;

            // Since we have reflection to get correct interfaces, using a dictionary
            // could be a good choice to get better performances
            if (associatedViewModelTypes.ContainsKey(sourcePageType))
            {
                viewModelType = associatedViewModelTypes[sourcePageType];
            }
            else
            {
                var currentAssembly = typeof(IViewModelNavigable).Assembly;

                var interfaces = sourcePageType.GetInterfaces()
                                    .Where(i => i.IsGenericType && i.Assembly == currentAssembly).ToList();

                if (interfaces == null || interfaces.Count <= 0)
                    return null;

                var typeVmArray = interfaces[0].GenericTypeArguments;

                if (typeVmArray == null || typeVmArray.Length <= 0)
                    return null;

                viewModelType = typeVmArray[0];

                associatedViewModelTypes.Add(sourcePageType, viewModelType);
            }

            if (viewModelType == null)
                return null;

            if (this.Container.Resolve(viewModelType) is IViewModelNavigable viewModelNavigable)
                return viewModelNavigable;

            return null;
        }



        /// <summary>
        /// Can we make something easier ? :)
        /// </summary>
        internal (Type PageType, Action<object, object, object> Refresh) GetViewModelType(Type sourcePageType)
        {
           (Type, Action<object, object, object>) vmType;

            if (this.dictionary.TryGetValue(sourcePageType, out vmType))
                return vmType;

            return vmType;
        }
    }

}
