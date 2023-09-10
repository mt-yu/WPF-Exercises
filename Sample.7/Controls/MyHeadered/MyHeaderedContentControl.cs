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
    ///     <MyNamespace:MyHeaderedContentControl/>
    ///
    /// </summary>
    public class MyHeaderedContentControl : ContentControl
    {
        static MyHeaderedContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyHeaderedContentControl), new FrameworkPropertyMetadata(typeof(MyHeaderedContentControl)));
        }




        public static DataTemplate GetHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(HeaderTemplateProperty);
        }

        public static void SetHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(HeaderTemplateProperty, value);
        }

        // Using a DependencyProperty as the backing store for HeaderTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.RegisterAttached("HeaderTemplate", typeof(DataTemplate), typeof(MyHeaderedContentControl), new PropertyMetadata(null, OnHeaderTemplateChanged));

        private static void OnHeaderTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var headeredContentControl = (MyHeaderedContentControl)d;
            headeredContentControl.OnHeaderTemplateChanged((DataTemplate)e.OldValue, (DataTemplate)e.NewValue);
        }

        protected virtual void OnHeaderTemplateChanged(DataTemplate oldHeaderTemplate, DataTemplate newHeaderTemplate)
        {
            //Helper.CheckTemplateAndTemplateSelector("Header", HeaderTemplateProperty, HeaderTemplateSelectorProperty, this);
        }

        public static object GetHeader(DependencyObject obj)
        {
            return (object)obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)    
        {
            obj.SetValue(HeaderProperty, value);
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(MyHeaderedContentControl), new PropertyMetadata(default(object), OnHeaderChanged));

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = (object)e.OldValue;
            var newValue = (object)e.NewValue;
            if (oldValue != newValue)
            {
                var target  = d as MyHeaderedContentControl;
                target?.OnHeaderChanged(oldValue, newValue);
            }
        }

        /// <summary>
        /// Header 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Header 属性旧值</param>
        /// <param name="newValue"></param>
        protected virtual void OnHeaderChanged(object oldValue, object newValue)
        {

        }
    }
}
