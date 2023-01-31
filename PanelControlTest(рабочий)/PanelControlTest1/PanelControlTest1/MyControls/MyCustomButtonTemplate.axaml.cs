using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace PanelControlTest1.MyControls
{
    public class MyCustomButtonTemplate : TemplatedControl
    {
        public static readonly StyledProperty<string?> FirstTextProperty =
AvaloniaProperty.Register<MyCustomButton, string?>(nameof(FirstText)); //����������� ������� �������� ������
        public string? FirstText //���������� �������
        {
            get { return GetValue(FirstTextProperty); }
            set { SetValue(FirstTextProperty, value); }
        }

        public static readonly StyledProperty<string?> SecondTextProperty =
    AvaloniaProperty.Register<MyCustomButton, string?>(nameof(SecondText)); //����������� �������� �������� ������

        public string? SecondText //���������� ������
        {
            get { return GetValue(SecondTextProperty); }
            set { SetValue(SecondTextProperty, value); }
        }


        public static readonly StyledProperty<ICommand> CommandProperty =
        AvaloniaProperty.Register<MyCustomButton, ICommand>(nameof(Command));

        public ICommand Command
        {
            get { return GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }

        }

        public MyCustomButtonTemplate()
        {

        }
    }
}
