using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace MyToDo.CommunityToolkit.Mvvm
{
    public class MainViewModel : ObservableObject
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
            set { name = value; OnPropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public RelayCommand<string> ShowCommand { get; set; }


        public void Show(string content)
        {
            Name = "点击了按钮！";
            Title = "我是标题";
            //MessageBox.Show(content);

            // 给 "Token1" 的地址发送一个 string 类型的值 content
            WeakReferenceMessenger.Default.Send(content, "Token1");
        }
    }
}
