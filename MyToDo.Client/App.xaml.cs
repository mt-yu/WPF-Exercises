using DryIoc;
using MyToDo.Client.Common;
using MyToDo.Client.Services;
using MyToDo.Client.ViewModels;
using MyToDo.Client.ViewModels.Dialogs;
using MyToDo.Client.Views;
using MyToDo.Client.Views.Dialogs;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace MyToDo.Client
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

        protected override void OnInitialized()
        {
            var service = App.Current.MainWindow.DataContext as IConfigureService;
            if (service != null)
            {
                service.Configure();
            }
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();

            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<AboutView,  AboutViewModel>();

            // dryIoc
            // 构造函数取名字
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            // 添加服务的地址
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:5030", serviceKey: "webUrl");

            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();

            containerRegistry.RegisterDialog<AddToDoView, AddToDoViewModel>();
            containerRegistry.RegisterDialog<AddMemoView, AddMemoViewModel>();

        }
    }
}
