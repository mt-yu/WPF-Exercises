using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace MyToDo.Client.ViewModels.Dialogs
{
    public class AddMemoViewModel : IDialogHostAware
    {
        public AddMemoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

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


        public void OnDialogOpened(IDialogParameters dialogParameters)
        {
        }
    }
}
