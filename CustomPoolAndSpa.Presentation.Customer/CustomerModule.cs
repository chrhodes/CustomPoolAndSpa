using CustomPoolAndSpa.DomainServices;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using CustomPoolAndSpa.Core;
using VNC;
using System;

namespace CustomPoolAndSpa.Presentation.Customer
{
    public class CustomerModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public CustomerModule(IUnityContainer container, IRegionManager regionManager)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _container = container;
            _regionManager = regionManager;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            // TODO(crhodes)
            // Should we be registering stuff here and not in App.Xaml.cs
            _container.RegisterType<ViewModels.ICustomerDetailViewModel, ViewModels.CustomerDetailViewModel>();
            _container.RegisterType<Views.ICustomerDetail, Views.CustomerDetail>();

            _container.RegisterType<ICustomerDataService, CustomerDataService>();

            _container.RegisterType<ViewModels.ICustomerViewModel, ViewModels.CustomerViewModel>();
            _container.RegisterType<Views.ICustomer, Views.Customer>();

            _container.RegisterType<ICustomersLookupDataService, CustomersLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _regionManager.RegisterViewWithRegion(RegionNames.CustomerRegion, typeof(Views.Customer));
            _regionManager.RegisterViewWithRegion(RegionNames.CustomerDetailRegion, typeof(Views.CustomerDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}