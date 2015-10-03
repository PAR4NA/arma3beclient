using System.Windows;
using Arma3BE.Client.Modules.Players;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace Arma3BE.Client.WPF
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = Shell as Window;
            Application.Current.MainWindow?.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(PlayersModule));
        }
    }
}