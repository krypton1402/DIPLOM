using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Test.UserControls
{
    public partial class Button1 : UserControl
    {
        public Button1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
