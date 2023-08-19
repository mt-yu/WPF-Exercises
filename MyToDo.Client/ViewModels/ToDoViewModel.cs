using MyToDo.Client.Services;
using MyToDo.Share.DataTransfers;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MyToDo.Client.ViewModels
{
    public class ToDoViewModel :BindableBase
    {
        private readonly IToDoService service;
        private ObservableCollection<ToDoDto> toDoDtos;
        private bool isRightDrawerOpen;

        public ToDoViewModel(IToDoService service)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            this.service = service;
            AddCommand = new DelegateCommand(Add);
            CreateTestData();
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

        private async void CreateTestData()
        {
            //for (int i = 0; i < 10; i++) 
            //{
            //    ToDoDtos.Add(new ToDoDto { Title=$"{i}-todo", Content=$"{i}-todo..." });
            //}
            var todoResult =  await service.GetAllAsync(new Share.Parameters.QueryParameter() { PageIndex = 0, PageSize = 100 });

            if (todoResult != null && todoResult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }
        }

    }
}
