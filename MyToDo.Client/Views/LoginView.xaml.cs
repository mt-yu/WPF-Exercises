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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyToDo.Client.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(IEventAggregator aggregator)
        {
            InitializeComponent();

            // 注册消息提示
            aggregator.RegisterMessage(arg =>
            {
                loginSnackBar.MessageQueue.Enqueue(arg.Message);
            }, "Login");
        }
    }
}
