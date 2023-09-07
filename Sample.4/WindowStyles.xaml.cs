using System;
using System.ComponentModel;
using System.Configuration.Internal;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Sample._4
{
    public class WindowStyles 
    {
        public static bool GetIsDragMoveable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragMoveableProperty);
        }

        public static void SetIsDragMoveable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragMoveableProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsDragMoveable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMoveableProperty =
            DependencyProperty.RegisterAttached("IsDragMoveable", typeof(bool), typeof(WindowStyles), new PropertyMetadata(false, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as Window;
            if (window != null)
            {
                if ((bool)e.NewValue)
                {
                    window.MouseLeftButtonDown += Window_MouseLeftButtonDown;
                }
                else
                {
                    window.MouseLeftButtonDown -= Window_MouseLeftButtonDown;
                }
            }
        }

        private static void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = sender as Window;
            if (window != null)
            {
                window.DragMove();
            }
        }

        static WindowStyles()
        {
            CloseWindowCommand = new RelayCommand<Window>(window => window.Close(), window => window != null);
            MinimizeWindowCommand = new RelayCommand<Window>(window => window.WindowState = WindowState.Minimized, window => window != null);
            RestoreWindowCommand = new RelayCommand<Window>(window => window.WindowState = WindowState.Normal, window => window != null);
            MaximizeWindowCommand = new RelayCommand<Window>(window => window.WindowState = WindowState.Maximized, window => window != null);
        }

        // 关闭窗体
        public static ICommand CloseWindowCommand { get; private set; }

        // 最小化窗体
        public static ICommand MinimizeWindowCommand { get; private set; }

        // 还原窗体
        public static ICommand RestoreWindowCommand { get; private set; }

        // 最大化窗体
        public static ICommand MaximizeWindowCommand { get; private set; }
    }
}