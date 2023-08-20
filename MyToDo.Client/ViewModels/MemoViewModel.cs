using DryIoc;
using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using MyToDo.Client.Extension;
using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
using MyToDo.Share.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDo.Client.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        private readonly IMemoService service;
        private readonly IDialogHostService dialogHost;
        private ObservableCollection<MemoDto> toDoDtos;
        private bool isRightDrawerOpen;
        private MemoDto currentDto;
        private string search;

        public MemoViewModel(IMemoService service, IContainerProvider containerProvider) : base(containerProvider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            this.service = service;
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<MemoDto>(Selected);
            DeleteCommand = new DelegateCommand<MemoDto>(Delete);
            dialogHost = containerProvider.Resolve<IDialogHostService>();
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<MemoDto> SelectedCommand { get; private set; }
        public DelegateCommand<MemoDto> DeleteCommand { get; private set; }

        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 编辑选中/新增对象
        /// </summary>
        public MemoDto CurrentDto
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
            CurrentDto = new MemoDto();
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
                    if (updateResult != null && updateResult.Status)
                    {
                        var memo = MemoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (memo != null)
                        {
                            memo.Title = CurrentDto.Title;
                            memo.Content = CurrentDto.Content;
                        }
                        IsRightDrawerOpen = false;
                    }
                }
                else
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult != null && addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Selected(MemoDto memo)
        {
            try
            {
                UpdateLoading(true);
                var memoResult = await service.GetFirstOfDefaultAsync(memo.Id);

                if (memoResult != null && memoResult.Status)
                {
                    CurrentDto = memoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Delete(MemoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除待办事项:{obj.Title} ?");
                if (dialogResult.Result == ButtonResult.OK)
                {
                    UpdateLoading(true);
                    var deleteResult = await service.DeleteAsync(obj.Id);
                    if (deleteResult.Status)
                    {
                        var model = MemoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                        if (model != null)
                        {
                            MemoDtos.Remove(model);
                        }
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
                var memoResult = await service.GetAllAsync(new QueryParameter()
                {
                    PageIndex = 0,
                    PageSize = 100,
                    Search = Search,
                });

                if (memoResult != null && memoResult.Status)
                {
                    MemoDtos.Clear();
                    foreach (var item in memoResult.Result.Items)
                    {
                        MemoDtos.Add(item);
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
