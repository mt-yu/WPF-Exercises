using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Share.DataTransfers
{
	/// <summary>
	/// 汇总
	/// </summary>
    public class SummaryDto : BaseDto
    {
		private int sum;
        private int completedCount;
        private int memoCount;
        private string completedRatio;

        private ObservableCollection<ToDoDto> todos;
        private ObservableCollection<MemoDto> memos;

		/// <summary>
		/// 待办事项总数
		/// </summary>
        public int Sum
		{
			get { return sum; }
			set { sum = value; OnPropertyChanged(); }
		}

		/// <summary>
		/// 完成待办事项数量
		/// </summary>
		public int CompletedCount
		{
			get { return completedCount; }
			set { completedCount = value; }
		}

		/// <summary>
		/// 备忘录数量
		/// </summary>
		public int MemoCount
		{
			get { return memoCount; }
			set { memoCount = value; }
		}

		/// <summary>
		/// 完成比例
		/// </summary>
		public string CompletedRatio
		{
			get { return completedRatio; }
			set { completedRatio = value; }
		}

		/// <summary>
		/// 待办事项列表
		/// </summary>
		public ObservableCollection<ToDoDto> ToDos
		{
			get { return todos; }
			set { todos = value; OnPropertyChanged(); }
		}

		/// <summary>
		/// 备忘录列表
		/// </summary>
        public ObservableCollection<MemoDto> Memos
        {
            get { return memos; }
            set { memos = value; OnPropertyChanged(); }
        }
    }
}
