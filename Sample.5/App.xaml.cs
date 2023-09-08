using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sample._5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Login();
        }

        private void Login()
        {
            var login = MessageBox.Show("输入用户名密码", "登录", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (login == MessageBoxResult.OK)
            {
                var main = new MainWindow();
                main.Show();
            }
            else
            {
                this.Shutdown();
            }
        }
    }
}
