using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sample._5.Models;
using System.Collections.ObjectModel;

namespace Sample._5.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            SelectedCommand = new RelayCommand<ListBoxModel>(Selected);
            Title = "Sample 5";
        }

        private void Selected(ListBoxModel? model)
        {
            if (model != null)
            {
                Title = model.Title;
            }
        }

        public RelayCommand<ListBoxModel> SelectedCommand { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ListBoxModel> lstModels { get; set; } = new ObservableCollection<ListBoxModel>()
        {
            new ListBoxModel() { Ico = "\xe626", Title = "Application" },
            new ListBoxModel() { Ico = "\xe77a", Title = "Opinion" },
            new ListBoxModel() { Ico = "\xe50a", Title = "Tasks" },
            new ListBoxModel() { Ico = "\xe669", Title = "Program" },
            new ListBoxModel() { Ico = "\xe502", Title = "Data" },
            new ListBoxModel() { Ico = "\xe77a", Title = "Opinion" },
            new ListBoxModel() { Ico = "\xe50a", Title = "Tasks" },
            new ListBoxModel() { Ico = "\xe669", Title = "Program" },
        };

        public ObservableCollection<DataGridModel> DataGridModels { get; set; } = new ObservableCollection<DataGridModel>()
        {
            new DataGridModel(){Name = "Vaughan", Address = "Delaware", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S1", BackColor = "#FF7000"},
            new DataGridModel(){Name = "Abbey", Address = "Florida", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S2", BackColor = "#FFC100"},
            new DataGridModel(){Name = "Dahlia", Address = "Illinois", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S1", BackColor = "#FF7000"},
            new DataGridModel(){Name = "Fallon", Address = "Tennessee", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S3", BackColor = "#59E6B5"},
            new DataGridModel(){Name = "Hannah", Address = "Washington", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S4", BackColor = "#FFC100"},
            new DataGridModel(){Name = "Laura", Address = "Mississippi", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S2", BackColor = "#59E6B5"},
            new DataGridModel(){Name = "Lauren", Address = "Wyoming", Email = "jack163@outlook.com", UserType = "Quality inspector", Status = "S3", BackColor = "#FFC100"},
        };
    }
}