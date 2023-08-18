using MyToDo.Client.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.ViewModels
{
    public class MemoViewModel : BindableBase
    {
        private ObservableCollection<MemoDto> memoDots;
        private bool isRightDrawerOpen;

        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            AddCommand = new DelegateCommand(Add);
            CreateTestData();
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

        private void CreateTestData()
        {
            for (int i = 0; i < 10; i++)
            {
                MemoDtos.Add(new MemoDto { Title = $"{i}-memo", Content = $"{i}-memo..." });
            }
        }
    }
}
