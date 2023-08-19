using System;

namespace MyToDo.Client.Common.Models
{
    public class BaseDto
    {
		private int id;
        private DateTime createDate;
        private DateTime updateDate;

        public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public DateTime CreateDate
		{
			get { return createDate; }
			set { createDate = value; }
		}

		public DateTime UpdateDate
		{
			get { return updateDate; }
			set { updateDate = value; }
		}

	}
}
