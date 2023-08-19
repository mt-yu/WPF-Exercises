using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace MyToDo.Client.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {
        private readonly IToDoService service;
        private ObservableCollection<ToDoDto> toDoDtos;
        private bool isRightDrawerOpen;
        private ToDoDto currentDto;
        private string search;
        private int selectedIndex;



        public ToDoViewModel(IToDoService service, IContainerProvider containerProvider) : base(containerProvider)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            this.service = service;
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<ToDoDto> SelectedCommand { get; private set; }
        public DelegateCommand<ToDoDto> DeleteCommand { get; private set; }


        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 编辑选中/新增对象
        /// </summary>
        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 下拉列表选中状态值
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 添加代办
        /// </summary>
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增":
                    Add();
                    break;
                case "查询":
                    Query();
                    break;
                case "保存":
                    Save();
                    break;
                default:
                    break;
            }
        }

        private void Add()
        {
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;
        }

        private void Query()
        {
            GetDataAsync();
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) || string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            try
            {
                UpdateLoading(true);
                // id 大于0 更新， 小于0 添加
                if (CurrentDto.Id > 0)
                {
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if(updateResult != null && updateResult.Status)
                    {
                        var todo = ToDoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                        }
                        IsRightDrawerOpen = false;
                    }
                }
                else
                {
                    var addResult =  await service.AddAsync(CurrentDto);
                    if (addResult != null && addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Selected(ToDoDto todo)
        {
            try
            {
                UpdateLoading(true);
                var todoResult = await service.GetFirstOfDefaultAsync(todo.Id);

                if (todoResult != null && todoResult.Status)
                {
                    CurrentDto = todoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Delete(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.Status)
                {
                    var model = ToDoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                    {
                        ToDoDtos.Remove(model);
                    }
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void GetDataAsync()
        {
            try
            {
                UpdateLoading(true);

                int? status = SelectedIndex == 0 ? null : SelectedIndex == 2 ? 1 : 0;

                var todoResult = await service.GetAllFilterAsync(new ToDoParameter()
                {
                    PageIndex = 0,
                    PageSize = 100,
                    Search = Search,
                    Status = status
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataAsync();
        }

    }
}
