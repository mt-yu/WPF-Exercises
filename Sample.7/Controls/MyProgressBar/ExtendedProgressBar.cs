using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample._7
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Sample._7"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Sample._7;assembly=Sample._7"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:ExtendedProgressBar/>
    ///
    /// </summary>
    public class ExtendedProgressBar : ProgressBar
    {
        static ExtendedProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedProgressBar), new FrameworkPropertyMetadata(typeof(ExtendedProgressBar)));
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ValueChanged += OnProgressBarValueChanged;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Value.CompareTo(0.0) != 0)
            {
                OnProgressBarValueChanged(this, new RoutedPropertyChangedEventArgs<double>(Angle,Value));
            }
        }

        public static readonly DependencyProperty AngleProperty =
    DependencyProperty.Register("Angle", typeof(double), typeof(ExtendedProgressBar),
        new PropertyMetadata(0.0));

        public double RotateAngle
        {
            get => (double)GetValue(RotateAngleProperty);
            set => SetValue(RotateAngleProperty, value);
        }

        public static readonly DependencyProperty RotateAngleProperty =
            DependencyProperty.Register("RotateAngle", typeof(double), typeof(ExtendedProgressBar),
                new PropertyMetadata(0.0));

        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }

        public static readonly DependencyProperty TipProperty =
     DependencyProperty.Register("Tip", typeof(string), typeof(ExtendedProgressBar),
         new PropertyMetadata(string.Empty));

        public string Tip
        {
            get => (string)GetValue(TipProperty);
            set => SetValue(TipProperty, value);
        }

        private void OnProgressBarValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var bar = sender as ExtendedProgressBar;
            if (bar != null)
            {
                var currentAngle = bar.Angle;
                double targetAngle = e.NewValue / bar.Maximum * 360.0;
                var indicator = this.GetTemplateChild("Indicator") as Arc;

                Storyboard story = new Storyboard();
                story.Changed += (s, args) =>
                {
                    if (indicator.Visibility == Visibility.Collapsed && targetAngle.CompareTo(0.0) != 0)
                    {
                        indicator.Visibility = Visibility.Visible;
                    }
                };
                story.Completed += (s, args) =>
                {
                    if (targetAngle.CompareTo(0.0) == 0)
                    {
                        indicator.Visibility = Visibility.Collapsed;
                    }
                };
                story.Children.Add(new DoubleAnimation(currentAngle, targetAngle, TimeSpan.FromMilliseconds(500)));
                Storyboard.SetTargetProperty(story.Children[0], new PropertyPath(AngleProperty));
                bar.BeginStoryboard(story, HandoffBehavior.SnapshotAndReplace);
                //DoubleAnimation anim = new DoubleAnimation(currentAngle, targetAngle, TimeSpan.FromMilliseconds(500));
                //bar.BeginAnimation(AngleProperty, anim, HandoffBehavior.SnapshotAndReplace);

            }
        }

    }
}
