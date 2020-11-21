using Prism.Ioc;
using Prism.Modularity;

namespace CustomPoolAndSpa.DomainServices
{
    public class CustomPoolAndSpaServicesModule : IModule
    {
        IContainerProvider _containerProvider;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _containerProvider = containerProvider;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // TODO(crhodes)
            // Maybe this is where we register the CustomPoolAndSpaDbContext

            //throw new NotImplementedException();
        }
    }
}
