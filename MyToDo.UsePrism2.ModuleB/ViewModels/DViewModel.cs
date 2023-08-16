using MyToDo.UsePrism2.ModuleB.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.UsePrism2.ModuleB.ViewModels
{
    public class DViewModel : IDialogAware
    {
        private readonly IEventAggregator aggregator;

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public DViewModel(IEventAggregator aggregator)
        {
            CancelCommand = new DelegateCommand(Cancel);
            SaveCommand = new DelegateCommand(OnDialogClosed);
            this.aggregator = aggregator;
        }

        private void Cancel()
        {
            //使用MessageEvent 发布一个Hello
            aggregator.GetEvent<MessageEvent>().Publish("Hello Event");
            //RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() 
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("Value", "Hello"); // 返回的结果，名字为Value的变量
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
        }
    }
} 
