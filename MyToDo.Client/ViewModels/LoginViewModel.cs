using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MyToDo.Client.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel()
        {
            CloseCommand = new DelegateCommand(Close);
        }

        private void Close()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        DelegateCommand CloseCommand { get; set; }

        public string Title { get; set; } = "雾山五行";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
