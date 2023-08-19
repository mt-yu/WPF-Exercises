using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        private ObservableCollection<MemoDto> memoDots;
        private bool isRightDrawerOpen;
        private readonly IMemoService service;

        public MemoViewModel(IMemoService service, IContainerProvider containerProvider) : base(containerProvider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            AddCommand = new DelegateCommand(Add);
            this.service = service;
        }

        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        public DelegateCommand AddCommand { get; private set; }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDots; }
            set { memoDots = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private async void GetDataAsync()
        {
            try
            {
                UpdateLoading(true);
                var memoResult = await service.GetAllAsync(new Share.Parameters.QueryParameter() { PageIndex = 0, PageSize = 100 });

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
