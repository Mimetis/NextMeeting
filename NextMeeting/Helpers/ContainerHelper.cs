using Autofac;
using NextMeeting.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Helpers
{
    public class ContainerHelper
    {
        private static ContainerHelper instance;

        public static ContainerHelper Current = instance ?? (instance = new ContainerHelper());

        /// <summary>
        /// Association between a view and a view model
        /// </summary>
        private Dictionary<Type, (Type, Action<object, object, object>)> dictionary = new Dictionary<Type, (Type, Action<object, object, object>)>();

        /// <summary>
        /// Access to the underlying autofac builder
        /// </summary>
        public ContainerBuilder Builder { get; }

        /// <summary>
        /// Get the container
        /// </summary>
        public IContainer Container { get; private set; }

        public ContainerHelper()
        {
            Builder = new ContainerBuilder();
        }

        /// <summary>
        /// Register a view model with its own view
        /// </summary>
        public void RegisterTypeWithViewModel<TViewModel, TPage>()
        {
            this.Builder.RegisterType<TViewModel>();

            Action<object, object, object> Refresh = new Action<object, object, object>(async (page, vm, parameter) =>
            {
                // pattern matching dude ! :)
                if (page is IPageViewModel<TViewModel> ipageViewModel && vm is TViewModel tvm)
                {
                    // settinf the correct viewmodel
                    ipageViewModel.ViewModel = tvm;

                    // call the refresh method
                    if (tvm is IRefresh tvmRefresh)
                        await tvmRefresh.RefreshAsync(parameter);
                }
            });

            dictionary.Add(typeof(TPage), (typeof(TViewModel), Refresh));

        }

        /// <summary>
        /// Build the container
        /// </summary>
        public void Build()
        {
            this.Container = this.Builder.Build();
        }

        internal bool ContainsViewModel(Type sourcePageType)
        {
            return this.dictionary.ContainsKey(sourcePageType);
        }

        internal (Type PageType, Action<object, object, object> Refresh) GetViewModelType(Type sourcePageType)
        {
           (Type, Action<object, object, object>) vmType;

            if (this.dictionary.TryGetValue(sourcePageType, out vmType))
                return vmType;

            return vmType;
        }
    }

}
