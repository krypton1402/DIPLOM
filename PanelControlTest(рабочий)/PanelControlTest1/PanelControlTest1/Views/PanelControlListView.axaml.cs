using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PanelControlTest1.Views
{
    public partial class PanelControlListView : UserControl
    { 
        
        
        public static readonly StyledProperty<Orientation?> OrientationProperty =
             AvaloniaProperty.Register<PanelControlListView, Orientation?>(nameof(Orientation));

       
        public PanelControlListView()
        {
            InitializeComponent();
            this.Orientation = Avalonia.Layout.Orientation.Horizontal;
        }
            
        public Orientation? Orientation
        {
            get { return GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

      
    }
}
