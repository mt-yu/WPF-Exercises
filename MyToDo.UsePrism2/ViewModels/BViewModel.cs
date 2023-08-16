using Prism.Mvvm;

namespace MyToDo.UsePrism2.ViewModels
{
    public class BViewModel : BindableBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BViewModel()
        {
            Name = "ViewB";
        }
    }
}
