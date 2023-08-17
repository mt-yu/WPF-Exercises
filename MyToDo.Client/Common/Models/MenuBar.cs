﻿using Prism.Mvvm;

namespace MyToDo.Client.Common.Models
{
	/// <summary>
	/// 系统导航菜单实体类
	/// </summary>
    public class MenuBar : BindableBase
    {
		private string icon;
		/// <summary>
		/// 菜单图标
		/// </summary>
		public string Icon
		{
			get { return icon; } 
			set { icon = value; }
		}

		private string title;
		/// <summary>
		/// 菜单命名
		/// </summary>
		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		private string nameSpace;
		/// <summary>
		/// 菜单命名空间
		/// </summary>
		public string NameSpace
		{
			get { return nameSpace; }
			set { nameSpace = value; }
		}


	}
}
