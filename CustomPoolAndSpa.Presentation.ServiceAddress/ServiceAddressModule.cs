using CustomPoolAndSpa.DomainServices;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using CustomPoolAndSpa.Core;
using System;
using VNC;

namespace CustomPoolAndSpa.Presentation.ServiceAddress
{
    public class ServiceAddressModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public ServiceAddressModule(IUnityContainer container, IRegionManager regionManager)
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
            _container.RegisterType<ViewModels.IServiceAddressDetailViewModel, ViewModels.ServiceAddressDetailViewModel>();
            _container.RegisterType<Views.IServiceAddressDetail, Views.ServiceAddressDetail>();

            _container.RegisterType<IServiceAddressDataService, ServiceAddressDataService>();

            _container.RegisterType<ViewModels.IServiceAddressViewModel, ViewModels.ServiceAddressViewModel>();
            _container.RegisterType<Views.IServiceAddress, Views.ServiceAddress>();

            _container.RegisterType<IServiceAddressLookupDataService, ServiceAddressLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _regionManager.RegisterViewWithRegion(RegionNames.ServiceAddressRegion, typeof(Views.ServiceAddress));
            _regionManager.RegisterViewWithRegion(RegionNames.ServiceAddressDetailRegion, typeof(Views.ServiceAddressDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}