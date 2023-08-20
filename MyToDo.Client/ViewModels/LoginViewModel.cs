using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MyToDo.Client.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private string account;
        private string passWord;


        public LoginViewModel()
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
        }

        DelegateCommand<string> ExecuteCommand { get; set; }

        public string Title { get; set; } = "雾山五行";

        public string Account
        {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }


        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        public event Action<IDialogResult> RequestClose;

        private void Execute(string arg)
        {
            switch (arg)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                default:
                    break;
            }
        }

        private void Login()
        {
        }

        private void LoginOut()
        {
        }

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
