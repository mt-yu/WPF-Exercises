using MyToDo.UsePrism2.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace MyToDo.UsePrism2.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public DelegateCommand<string> OpenCommand { get; private set; }

        public MainViewModel()
        {
            OpenCommand = new DelegateCommand<string>(Open);
        }

        private object body;

        public object Body
        {
            get { return body; }
            set { body = value; RaisePropertyChanged(); }
        }


        private void Open(string obj)
        {
            switch (obj) 
            {
                case "ViewA":
                    Body = new AView();
                    break;
                case "ViewB":
                    Body = new BView();
                    break;
                case "ViewC":
                    Body = new CView();
                    break;
            }
        }
    }
}
