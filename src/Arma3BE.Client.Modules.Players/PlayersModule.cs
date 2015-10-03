using Arma3BE.Client.Modules.Players.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Arma3BE.Client.Modules.Players
{
    public class PlayersModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PlayersModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("PlayersRegion", typeof(PlayersView));
        }
    }
}