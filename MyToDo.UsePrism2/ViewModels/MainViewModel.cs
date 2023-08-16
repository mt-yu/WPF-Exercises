using MyToDo.UsePrism2.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace MyToDo.UsePrism2.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        /// <summary>
        /// 区域导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        public DelegateCommand<string> OpenCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }


        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            OpenCommand = new DelegateCommand<string>(Open2);
            BackCommand = new DelegateCommand(Back);
            this.regionManager = regionManager;
            this.dialogService = dialogService;
        }

        private void Back()
        {
            if (journal.CanGoBack)
                journal.GoBack();
        }

        private void Open2(string obj)
        {
            if (obj == "DView")
            {
                DialogParameters keys = new DialogParameters();
                keys.Add("Title", "测试弹窗");
                dialogService.ShowDialog(obj, keys, callback => 
                {
                    if(callback.Result == ButtonResult.OK) 
                    {
                        string result = callback.Parameters.GetValue<string>("Value");
                    }
                });
            }
            else
            {
                Open(obj);
            }
        }

        private void Open(string obj)
        {

            NavigationParameters keys = new NavigationParameters();
            keys.Add("Title", "Hello!");

            // 首先通过IRegionManager 接口获取到全局定义的可用区域
            // 往这个区域动态去设置内容
            // 设置内容的方式是通过依赖注入的形式
            regionManager.Regions["ContentRegion"].RequestNavigate(obj, callBack=> 
            {
                if ((bool)callBack.Result)
                {
                    journal = callBack.Context.NavigationService.Journal;
                }
            },keys);
        }
    }
}
