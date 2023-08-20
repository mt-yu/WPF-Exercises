using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using MyToDo.Share.DataTransfers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace MyToDo.Client.ViewModels.Dialogs
{
    public class AddToDoViewModel : BindableBase, IDialogHostAware
    {
        public AddToDoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        private ToDoDto model;

        /// <summary>
        /// 新增或编辑的实体
        /// </summary>
        public ToDoDto Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
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
            if (!string.IsNullOrWhiteSpace(Model.Title) && !string.IsNullOrWhiteSpace(Model.Content))
            {
                if (DialogHost.IsDialogOpen(DialogHostName))
                {
                    DialogParameters @params = new DialogParameters();
                    @params.Add("Value", Model);
                    DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, @params));
                }
            }
        }

        public void OnDialogOpened(IDialogParameters dialogParameters)
        {
            if (dialogParameters.ContainsKey("Value"))
            {
                Model = dialogParameters.GetValue<ToDoDto>("Value");
            }
            else
            {
                Model = new ToDoDto();
            }
        }
    }
}
