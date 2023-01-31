using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PanelControlTest1.Views
{
    public partial class CoordinatePanel : UserControl
    {
        public CoordinatePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
