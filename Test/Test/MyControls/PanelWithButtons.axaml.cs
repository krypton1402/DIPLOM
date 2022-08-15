using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;

namespace Test.MyControls
{

    public class PanelWithButtons : TemplatedControl
    {
        public static readonly StyledProperty<Orientation?> OrientationProperty =
             AvaloniaProperty.Register<PanelWithButtons, Orientation?>(nameof(Orientation));

        public Orientation? Orientation
        {
            get { return GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
    }

    
}
