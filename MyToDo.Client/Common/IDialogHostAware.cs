using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.Common
{
    internal interface IDialogHostAware
    {
        /// <summary>
        /// DialogHost名称
        /// </summary>
        string DialogHostName { get; set; }

        /// <summary>
        /// 打开过程中执行
        /// </summary>
        /// <param name="dialogParameters"></param>
        void OnDialogOpened(IDialogParameters dialogParameters);

        /// <summary>
        /// 确定命令
        /// </summary>
        DelegateCommand SaveCommand { get;set; }

        /// <summary>
        /// 取消命令
        /// </summary>
        DelegateCommand CancelCommand { get; set; }
    }
}
