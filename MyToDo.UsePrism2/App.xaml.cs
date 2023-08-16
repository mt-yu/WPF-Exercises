using MyToDo.UsePrism2.Views;
using Prism.DryIoc;
using Prism.Ioc;
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
            containerRegistry.RegisterForNavigation<AView>();
            containerRegistry.RegisterForNavigation<BView>();
            containerRegistry.RegisterForNavigation<CView>();
        }
    }
}
