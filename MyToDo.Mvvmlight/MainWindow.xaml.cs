using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
namespace MyToDo.Mvvmlight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            // 注册一个接受string 类型参数的消息，地址是"Token1"
            Messenger.Default.Register<string>(this, "Token1", Show);
        }

        private void Show(string obj)
        {
            MessageBox.Show(obj);
        }
    }
}
