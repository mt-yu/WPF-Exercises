using MyToDo.UsePrism2.ModuleB.Event;
using Prism.Events;
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

namespace MyToDo.UsePrism2.ModuleB.Views
{
    /// <summary>
    /// DView.xaml 的交互逻辑
    /// </summary>
    public partial class DView : UserControl
    {
        private readonly IEventAggregator aggregator;

        public DView(IEventAggregator aggregator)
        {
            InitializeComponent();
            this.aggregator = aggregator;
            this.aggregator.GetEvent<MessageEvent>().Subscribe(SubMessage);
        }

        private void SubMessage(string msg)
        {
            MessageBox.Show($"接受消息:{msg}");
            aggregator.GetEvent<MessageEvent>().Unsubscribe(SubMessage);
        }
    }
}
