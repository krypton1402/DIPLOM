using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Test.MyControls
{
    public class MyToggleButton : ToggleButton
    {
         public static readonly StyledProperty<string?> FirstTextProperty =
    AvaloniaProperty.Register<MyCustomButton, string?>(nameof(FirstText));

        public string? FirstText
        {
            get { return GetValue(FirstTextProperty); }
            set { SetValue(FirstTextProperty, value); }
        }

        public static readonly StyledProperty<string?> SecondTextProperty =
    AvaloniaProperty.Register<MyCustomButton, string?>(nameof(SecondText));

        public string? SecondText
        {
            get { return GetValue(SecondTextProperty); }
            set { SetValue(SecondTextProperty, value); }
        }
    }
}
