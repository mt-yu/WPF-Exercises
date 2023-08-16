using MyToDo.UsePrism2.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MyToDo.UsePrism2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<AView>();
            //containerRegistry.RegisterForNavigation<BView>();
            containerRegistry.RegisterForNavigation<CView>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleA.ModelAProfile>();
            moduleCatalog.AddModule<ModuleB.ModelBProfile>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
