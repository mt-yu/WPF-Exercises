using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyToDo.UsePrism2.ModuleA.ViewModels
{
    public class AViewModel : BindableBase, IConfirmNavigationRequest//  INavigationAware
    {
        public AViewModel()
        {
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = navigationContext.Parameters;
            if (parameters.ContainsKey("Title"))
            {
                Title = parameters.GetValue<string>("Title");
            }
        }

        /// <summary>
        /// 每次重新导航的时候，是否重用之前的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = true;

            if (MessageBox.Show("确认导航？", "温馨提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                result = false;
            }

            continuationCallback(result);
        }
    }
}
