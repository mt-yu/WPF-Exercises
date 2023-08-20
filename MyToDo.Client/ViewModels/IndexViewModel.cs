using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using MyToDo.Client.Common.Models;
using MyToDo.Share.DataTransfers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace MyToDo.Client.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        public ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<ToDoDto> toDoDtos;
        public ObservableCollection<MemoDto> memoDtos;
        private readonly IDialogHostService dialog;

        public IndexViewModel(IDialogHostService dialog)
        {
            CreateTaskBars();
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.dialog = dialog;
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增待办": AddToDo(); break;
                case "新增备忘录": AddMemo(); break;
                default:
                    break;
            }
        }

        private void AddToDo()
        {
            dialog.ShowDialog("AddToDoView", null);
        }

        private void AddMemo()
        {
            dialog.ShowDialog("AddMemoView", null);
        }

        void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>
            {
                new TaskBar() { Icon = "ClockFast", Title = "汇总", Content = "9", Color = "#0097ff", Target = "" },
                new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#0eb138", Target = "" },
                new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#00b4dd", Target = "" },
                new TaskBar() { Icon = "PlaylistStar", Title = "备忘录 ", Content = "19", Color = "#ff9f00", Target = "" }
            };
        }

        void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title = @$"{i}-todo", Content = @$"{i}-todo..." });
                MemoDtos.Add(new MemoDto() { Title = @$"{i}-memo", Content = @$"{i}-memo..." });
            }
        }
    }
}
