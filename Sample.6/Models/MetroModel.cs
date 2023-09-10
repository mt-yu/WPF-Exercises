using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System.Windows.Media;

namespace Sample._6.Models
{
    public class MetroModel
    {
        public string Name { get; set; }

        public Brush Color { get; set; }

        public TransitionEffect Effact { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public PackIconKind IconKind { get; set; }
    }
}
