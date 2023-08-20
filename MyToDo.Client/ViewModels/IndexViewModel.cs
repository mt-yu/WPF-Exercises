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
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDo.Client.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        public ObservableCollection<TaskBar> taskBars;
        private readonly IDialogHostService dialog;
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;

        public IndexViewModel(IContainerProvider provider, IDialogHostService dialog) : base(provider)
        {
            CreateTaskBars();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.dialog = dialog;
            this.toDoService = provider.Resolve<IToDoService>();
            this.memoService = provider.Resolve<IMemoService>();
            EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            ToDoCompletedCommand = new DelegateCommand<ToDoDto>(Completed);
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<ToDoDto> EditToDoCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }
        public DelegateCommand<ToDoDto> ToDoCompletedCommand { get; private set; }

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private SummaryDto summary;

        /// <summary>
        /// 首页统计
        /// </summary>
        public SummaryDto Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(); }
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
        async void AddToDo(ToDoDto model = null)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
            {
                param.Add("Value", model);
            }

            var dialogResult = await dialog.ShowDialog("AddToDoView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                var todo = dialogResult.Parameters.GetValue<ToDoDto>("Value");
                if (todo.Id > 0)
                {
                    var updateResult = await toDoService.UpdateAsync(todo);
                    if (updateResult.Status)
                    {
                        var todoModel = Summary.ToDos.FirstOrDefault(t => t.Id.Equals(todo.Id));
                        if (todoModel != null)
                        {
                            todoModel.Title = todo.Title;
                            todoModel.Content = todo.Content;
                            todoModel.Status = todo.Status;
                        }
                    }
                }
                else
                {
                    var addResult = await toDoService.AddAsync(todo);
                    if (addResult.Status)
                    {
                        Summary.ToDos.Add(addResult.Result);
                    }
                }
            }
        }

        /// <summary>
        /// 添加备忘录
        /// </summary>
        async void AddMemo(MemoDto model = null)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
            {
                param.Add("Value", model);
            }

            var dialogResult = await dialog.ShowDialog("AddMemoView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                if (memo.Id > 0)
                {
                    var updateResult = await memoService.UpdateAsync(memo);
                    if (updateResult.Status)
                    {
                        var memoModel = Summary.Memos.FirstOrDefault(t => t.Id.Equals(memo.Id));
                        if (memoModel != null)
                        {
                            memoModel.Title = memo.Title;
                            memoModel.Content = memo.Content;
                        }
                    }
                }
                else
                {
                    var addResult = await memoService.AddAsync(memo);
                    if (addResult.Status)
                    {
                        Summary.Memos.Add(addResult.Result);
                    }
                }
            }
        }

        async void Completed(ToDoDto obj)
        {
            var update = await toDoService.UpdateAsync(obj);
            if (update.Status)
            {
                var todo = Summary.ToDos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                if (todo != null)
                {
                    Summary.ToDos.Remove(todo);
                }
            }
        }

        void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>
            {
                new TaskBar() { Icon = "ClockFast", Title = "汇总", Color = "#0097ff", Target = "" },
                new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Color = "#0eb138", Target = "" },
                new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Color = "#00b4dd", Target = "" },
                new TaskBar() { Icon = "PlaylistStar", Title = "备忘录 ", Color = "#ff9f00", Target = "" }
            };
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summary = await toDoService.SummaryAsync();
            if (summary.Status)
            {
                Summary = summary.Result;
                Refresh();
            }
            base.OnNavigatedTo(navigationContext);
            //GetDataAsync();
        }

        void Refresh()
        {
            TaskBars[0].Content = Summary.Sum.ToString();
            TaskBars[1].Content = Summary.CompletedCount.ToString();
            TaskBars[2].Content = Summary.CompletedRatio;
            TaskBars[3].Content = Summary.MemoCount.ToString();
        }
    }
}
