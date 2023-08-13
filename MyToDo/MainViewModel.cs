using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MyToDo
{
    public class MainViewModel
    {

        public string Name { get; set; }

        public MainViewModel()
        {
            ShowCommand = new MyCommand(Show);
            Name = "MtTest";
        }

        public MyCommand ShowCommand { get; set; }

        public void Show()
        {
            Name = "点击了按钮！";
            MessageBox.Show(Name);
        }
    }
}
