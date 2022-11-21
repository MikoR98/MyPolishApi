using MoneyManager.Interfaces;
using MoneyManager.Services;
using MoneyManager.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Windows;

namespace MoneyManager
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var mainWindow = Container.Resolve<MainWindow>();

            return mainWindow;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRestService, RestService>();
            containerRegistry.RegisterSingleton<AppConfiguration>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Login));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(HomePage));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ExpensesAnalysis));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Budget));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Goals));
        }
    }
}
