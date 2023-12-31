﻿using MaterialDesignThemes.Wpf;
using MyToDo.Client.Common;
using MyToDo.Client.Extension;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyToDo.Client.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogHostService dialogHostService;

        public MainView(IEventAggregator aggregator, IDialogHostService dialogHostService)
        {
            InitializeComponent();

            // 注册提示消息
            aggregator.RegisterMessage(arg =>
            {
                snackbar.MessageQueue.Enqueue(arg.Message);
            });

            // 注册等待消息窗口
            aggregator.Register(arg =>
            {
                dialogHost.IsOpen = arg.IsOpen;

                if (dialogHost.IsOpen)
                {
                    dialogHost.DialogContent = new ProgressView();
                }
            });

            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) => 
            {
                var btn = (ContentControl)FindName("btnMax");
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    ((PackIcon)(btn).Content).Kind = PackIconKind.WindowMaximize;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    ((PackIcon)(btn).Content).Kind = PackIconKind.WindowRestore;
                }
            };
            btnClose.Click += async (s, e) =>
            {
                var dialogResult = await dialogHostService.Question("温馨提示", "确认退出系统?");
                if (dialogResult.Result == ButtonResult.OK)
                {
                    this.Close();
                }
            };
            cloroZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            cloroZone.MouseDoubleClick += (s, e) =>
            {
                var btn = (ContentControl)FindName("btnMax");
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                    ((PackIcon)(btn).Content).Kind = PackIconKind.WindowRestore;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                    ((PackIcon)(btn).Content).Kind = PackIconKind.WindowMaximize;
                }
            };
            this.dialogHostService = dialogHostService;
            this.dialogHostService = dialogHostService;
        }

        private void menuBar_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 有助于滚动条
            var dependencyObject = Mouse.Captured as DependencyObject;

            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            // 收起侧边栏 
            MenuToggleButton.IsChecked = false;
        }
    }
}
