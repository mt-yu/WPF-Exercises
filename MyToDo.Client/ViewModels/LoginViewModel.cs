using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
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
        private readonly ILoginService loginService;

        public LoginViewModel(ILoginService loginService)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.loginService = loginService;
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

        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(Account) || string.IsNullOrWhiteSpace(PassWord))
            {
                return;
            }

            var result = await loginService.LoginAsync(new UserDto() { Account = Account, PassWord = PassWord});

            if (result.Status)
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }

            // 登录失败提示。。
        }

        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
