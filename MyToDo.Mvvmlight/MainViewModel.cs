using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MyToDo.Mvvmlight
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "MtTest";
            ShowCommand = new RelayCommand<string>(Show);
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        public RelayCommand<string> ShowCommand { get; set; }


        public void Show(string content)
        {
            Name = "点击了按钮！";
            Title = "我是标题";
            //MessageBox.Show(content);

            // 给 "Token1" 的地址发送一个 string 类型的值 content
            Messenger.Default.Send(content, "Token1");
        }
    }
}
