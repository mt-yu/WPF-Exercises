using MyToDo.UsePrism.Temp.Modules.ModuleName;
using MyToDo.UsePrism.Temp.Services;
using MyToDo.UsePrism.Temp.Services.Interfaces;
using MyToDo.UsePrism.Temp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MyToDo.UsePrism.Temp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
