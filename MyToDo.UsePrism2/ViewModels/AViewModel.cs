using Prism.Mvvm;

namespace MyToDo.UsePrism2.ViewModels
{
    public class AViewModel : BindableBase
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public AViewModel()
        {
            Name = "ViewA";
        }
    }
}
