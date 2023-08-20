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
        private int selectedIndex;
        private RegisterUserDto userDto;
        private readonly ILoginService loginService;

        public LoginViewModel(ILoginService loginService)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.loginService = loginService;
            UserDto = new RegisterUserDto();
        }

        /// <summary>
        /// 切记 事件要公开
        /// </summary>
        public DelegateCommand<string> ExecuteCommand { get; private set; }

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

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        public RegisterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }


        public event Action<IDialogResult> RequestClose;

        private void Execute(string arg)
        {
            switch (arg)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                case "GoRegister": GoRegister(); break;
                case "Register": Register(); break;
                case "ReturnLogin": ReturnLogin(); break;
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

            var result = await loginService.LoginAsync(new UserDto() { Account = Account, PassWord = PassWord });

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

        private void GoRegister()
        {
            SelectedIndex = 1;
        }

        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(UserDto.Account) || string.IsNullOrWhiteSpace(UserDto.UserName) || string.IsNullOrWhiteSpace(UserDto.PassWord))
            {
                return;
            }

            if (UserDto.PassWord != UserDto.NewPassWord)
            {
                // 验证失败提示...
                return;
            }

            var result = await loginService.RegisterAsync(new UserDto()
            {
                Account = UserDto.Account,
                UserName = UserDto.UserName,
                PassWord = UserDto.PassWord
            });
            if (result != null && result.Status)
            {
                // 注册成功
                SelectedIndex = 0;
            }

            // 注册失败提示...
        }

        private void ReturnLogin()
        {
            SelectedIndex = 0;
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
