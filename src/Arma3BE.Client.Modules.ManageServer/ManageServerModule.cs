using Arma3BE.Client.Modules.ManageServer.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Arma3BE.Client.Modules.ManageServer
{
    public class ManageServerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ManageServerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("PlayersRegion", typeof(ManageServerView));
        }
    }
}