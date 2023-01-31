using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PanelControlTest1.Views
{
    public partial class FSPanel : UserControl
    {
        public FSPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
