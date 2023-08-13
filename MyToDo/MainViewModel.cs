using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MyToDo
{
    public class MainViewModel : ViewModelBase
    {
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


        public MainViewModel()
        {
            ShowCommand = new MyCommand(Show);
            Name = "MtTest";
        }

        public MyCommand ShowCommand { get; set; }


        public void Show()
        {
            Name = "点击了按钮！";
            Title = "我是标题";
            MessageBox.Show(Name);
        }
    }
}
