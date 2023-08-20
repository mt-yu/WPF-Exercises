using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MyToDo.Client.Common
{
    public class DialogHostService : DialogService, IDialogHostService
    {
        private readonly IContainerExtension containerExtension;

        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this.containerExtension = containerExtension;
        }



        /// <summary>
        /// 自定义的对话主机服务， 有点复杂。。
        /// 以下代码参考 Base 实现
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="dialogHostName"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "RootDialog")
        {
            if (parameters == null)
            {
                parameters = new DialogParameters();
            }

            // 从容器当中去除弹出窗口的实例
            FrameworkElement frameworkElement = containerExtension.Resolve<object>(name) as FrameworkElement;

            // 验证实例的有效性
            if (frameworkElement == null)
            {
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");
            }

            if (frameworkElement != null && frameworkElement.DataContext == null && !ViewModelLocator.GetAutoWireViewModel(frameworkElement).HasValue)
            {
                ViewModelLocator.SetAutoWireViewModel(frameworkElement, true);
            }

            IDialogHostAware dialogAware = frameworkElement.DataContext as IDialogHostAware;
            if (dialogAware == null)
            {
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");
            }

            dialogAware.DialogHostName = dialogHostName;

            DialogOpenedEventHandler eventHandler = (sender, e) =>
            {
                if (dialogAware is IDialogHostAware aware)
                {
                    aware.OnDialogOpened(parameters);
                }
                e.Session.UpdateContent(frameworkElement);
            };

            return (IDialogResult)await DialogHost.Show(frameworkElement, dialogAware.DialogHostName, eventHandler);
        }
    }
}
