using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace MyToDo.Microsoft.Toolkit.Mvvm
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
