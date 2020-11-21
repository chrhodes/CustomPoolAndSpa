using CustomPoolAndSpa.DomainServices;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using CustomPoolAndSpa.Core;
using VNC;
using System;

namespace CustomPoolAndSpa.Presentation.ServiceCall
{
    public class ServiceCallModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public ServiceCallModule(IUnityContainer container, IRegionManager regionManager)
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
            _container.RegisterType<ViewModels.IServiceCallDetailViewModel, ViewModels.ServiceCallDetailViewModel>();
            _container.RegisterType<Views.IServiceCallDetail, Views.ServiceCallDetail>();

            _container.RegisterType<IServiceCallDataService, ServiceCallDataService>();

            _container.RegisterType<ViewModels.IServiceCallViewModel, ViewModels.ServiceCallViewModel>();
            _container.RegisterType<Views.IServiceCall, Views.ServiceCall>();

            _container.RegisterType<IServiceCallLookupDataService, ServiceCallLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _regionManager.RegisterViewWithRegion(RegionNames.ServiceCallRegion, typeof(Views.ServiceCall));
            _regionManager.RegisterViewWithRegion(RegionNames.ServiceCallDetailRegion, typeof(Views.ServiceCallDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}