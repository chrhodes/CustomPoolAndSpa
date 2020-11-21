using CustomPoolAndSpa.DomainServices;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using CustomPoolAndSpa.Core;
using CustomPoolAndSpa.Presentation.LookupMaintenance.ViewModels;
using CustomPoolAndSpa.DomainServices.Services;
using System;
using VNC;

namespace CustomPoolAndSpa.Presentation.LookupMaintenance
{
    public class LookupMaintenanceModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public LookupMaintenanceModule(IUnityContainer container, IRegionManager regionManager)
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
            _container.RegisterType<ViewModels.ILookupMaintenanceDetailViewModel, ViewModels.LookupMaintenanceDetailViewModel>();
            _container.RegisterType<Views.ILookupMaintenanceDetail, Views.LookupMaintenanceDetail>();

            _container.RegisterType<ILookupMaintenanceDataService, LookupMaintenanceDataService>();

            _container.RegisterType<ViewModels.ILookupMaintenanceViewModel, ViewModels.LookupMaintenanceViewModel>();
            _container.RegisterType<Views.ILookupMaintenance, Views.LookupMaintenance>();

            _container.RegisterType<ILookupMaintenanceLookupDataService, LookupMaintenanceLookupDataService>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _regionManager.RegisterViewWithRegion(RegionNames.LookupMaintenanceRegion, typeof(Views.LookupMaintenance));
            _regionManager.RegisterViewWithRegion(RegionNames.LookupMaintenanceDetailRegion, typeof(Views.LookupMaintenanceDetail));

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}