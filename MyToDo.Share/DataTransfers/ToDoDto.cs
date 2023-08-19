using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Share.DataTransfers
{
    /// <summary>
    /// 待办事项 数据传输层 实体
    /// </summary>
    public class ToDoDto : BaseDto
    {
        string? title;
        string? content;
        int status;

        public string? Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public string? Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

        public int Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }
    }
}
