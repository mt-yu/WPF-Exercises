﻿using MyToDo.Client.Common;
using MyToDo.Client.Common.Models;
using MyToDo.Client.Extension;
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
using System.Windows.Controls.Primitives;

namespace MyToDo.Client.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private readonly IContainerProvider containerProvider;
        private IRegionNavigationJournal journal;

        public MainViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            this.regionManager = regionManager;
            this.containerProvider = containerProvider;
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
            LoginOutCommand = new DelegateCommand(LoginOut);
        }

        private void Navigate(MenuBar bar)
        {
            if (bar == null || string.IsNullOrEmpty(bar.NameSpace))
                return;

            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(bar.NameSpace, back => 
            {
                journal = back.Context.NavigationService.Journal;
            });
        }

        private void LoginOut()
        {
            App.LoginOut(containerProvider);
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }
        public DelegateCommand LoginOutCommand { get; private set; }
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }


        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar() { Icon = "Notebook", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }

        /// <summary>
        /// 配置首页初始化参数
        /// </summary>
        public void Configure()
        {
            UserName = AppSession.UserName;
            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}
