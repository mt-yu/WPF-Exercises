using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using MyToDo.Client.Common.Models;
using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace MyToDo.Client.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        public ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<ToDoDto> toDoDtos;
        public ObservableCollection<MemoDto> memoDtos;
        private readonly IDialogHostService dialog;
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;

        public IndexViewModel(IContainerProvider provider, IDialogHostService dialog) : base(provider)
        {
            CreateTaskBars();
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.dialog = dialog;
            this.toDoService = provider.Resolve<IToDoService>();
            this.memoService = provider.Resolve<IMemoService>();
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

        /// <summary>
        /// 添加待办事项
        /// </summary>
        async void AddToDo()
        {
            var dialogResult = await dialog.ShowDialog("AddToDoView", null);
            if (dialogResult.Result == ButtonResult.OK)
            {
                var todo = dialogResult.Parameters.GetValue<ToDoDto>("Value");
                if (todo.Id > 0)
                {

                }
                else
                {
                    var addResult = await toDoService.AddAsync(todo);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                    }
                }
            }
        }

        /// <summary>
        /// 添加备忘录
        /// </summary>
        async void AddMemo()
        {
            var dialogResult = await dialog.ShowDialog("AddMemoView", null);
            if (dialogResult.Result == ButtonResult.OK)
            {
                var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                if (memo.Id > 0)
                {

                }
                else
                {
                    var addResult = await memoService.AddAsync(memo);
                    if (addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
                    }
                }
            }
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataAsync();
        }

        async void GetDataAsync()
        {
            try
            {
                UpdateLoading(true);

                //int? status = SelectedIndex == 0 ? null : SelectedIndex == 2 ? 1 : 0;

                var todoResult = await toDoService.GetAllFilterAsync(new ToDoParameter()
                {
                    PageIndex = 0,
                    PageSize = 100,
                    //Status = status
                });

                if (todoResult != null && todoResult.Status)
                {
                    ToDoDtos.Clear();
                    foreach (var item in todoResult.Result.Items)
                    {
                        ToDoDtos.Add(item);
                    }
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

    }
}
