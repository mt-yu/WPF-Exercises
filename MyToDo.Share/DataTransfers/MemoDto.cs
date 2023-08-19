using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Share.DataTransfers
{
    public class MemoDto : BaseDto
    {
        string? title;
        string? content;

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
    }
}
