using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace MyToDo.Client.ViewModels
{
    public class MessageViewModel : BindableBase, IDialogHostAware
    {
        public MessageViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }


        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.Cancel));
            }
        }

        private void Save()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters @params = new DialogParameters();
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, @params));
            }
        }


        public void OnDialogOpened(IDialogParameters parameters)
        {
            if(parameters.ContainsKey("Title"))
                Title = parameters.GetValue<string>("Title");
            if (parameters.ContainsKey("Content"))
                Content = parameters.GetValue<string>("Content");
        }
    }
}
