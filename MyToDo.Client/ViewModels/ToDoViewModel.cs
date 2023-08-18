using MyToDo.Client.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.ViewModels
{
    public class ToDoViewModel :BindableBase
    {
        private ObservableCollection<ToDoDto> toDoDtos;
        private bool isRightDrawerOpen;

        public ToDoViewModel()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            CreateTestData();
            AddCommand = new DelegateCommand(Add);
        }

        public DelegateCommand AddCommand { get; private set; }

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
        /// 添加代办
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        private void CreateTestData()
        {
             for (int i = 0; i < 10; i++) 
            {
                ToDoDtos.Add(new ToDoDto { Title=$"{i}-todo", Content=$"{i}-todo..." });
            }
        }

    }
}
