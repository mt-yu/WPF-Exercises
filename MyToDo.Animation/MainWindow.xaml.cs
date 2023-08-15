using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace MyToDo.Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.By = -30;
            //animation.From = btn.Width; // 设置动画初始值
            //animation.To = btn.Width - 30; // 设置动画的结束值
            animation.Duration = TimeSpan.FromSeconds(2); // 设置动画的持续时间
            //animation.AutoReverse = true; // 是否往返执行
            //animation.RepeatBehavior = new RepeatBehavior(3); // RepeatBehavior.Forever; //执行周期  

            animation.Completed += Animation_Completed;

            // 在当前按钮上执行该动画
            btn.BeginAnimation(FrameworkElement.WidthProperty, animation);
        }

        private void Animation_Completed(object? sender, EventArgs e)
        {
            btn.Content = "动画已完成";
        }
    }
}
