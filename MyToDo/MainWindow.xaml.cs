using System;
using System.CodeDom;
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

namespace MyToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            List<CustmeColor> testDatas = new List<CustmeColor>();
            testDatas.Add(new CustmeColor("#ff0000", "Red"));
            testDatas.Add(new CustmeColor("#00ff00", "Green"));
            testDatas.Add(new CustmeColor("#0000ff", "Blue"));
            testDatas.Add(new CustmeColor("#556677", "556677"));
            lstTest.ItemsSource = testDatas;
            dgTest.ItemsSource = testDatas;

            //this.DataContext = new BindingTest()
            //{
            //    Name = "MtTest"
            //};
        }
    }

    public class CustmeColor
    {
        public CustmeColor(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
