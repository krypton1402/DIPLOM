using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using PanelControlTest1.Models;
using System;
using System.Runtime.CompilerServices;

namespace PanelControlTest1.Views
{
    public partial class MyPanel : StackPanel
    {
        private uint _numButtons;
        private Button[] _buttons;
        private AxiOMAPanel _panel;
        private PanelOrientation _orientation;
        public static readonly StyledProperty<Orientation> OrientationProperty =
              StackLayout.OrientationProperty.AddOwner<StackPanel>();
        public static readonly StyledProperty<double> SpacingProperty =
            StackLayout.SpacingProperty.AddOwner<StackPanel>();
        public Orientation Orientation
        {
            get { return GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        public double Spacing
        {
            get { return GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

      


        protected override Size MeasureOverride(Size availableSize)
        {

            var children = Children;//здесь определить кнопки
            Size desiredSize = new Size();
            bool fHorizontal = (Orientation == Orientation.Horizontal);
            Size layoutSlotSize = availableSize;
            double spacing = Spacing;
            bool hasVisibleChild = false;
            if (fHorizontal)
            {
                layoutSlotSize = layoutSlotSize.WithWidth(Double.PositiveInfinity);
            }
            else
            {
                layoutSlotSize = layoutSlotSize.WithHeight(Double.PositiveInfinity);
            }

            for (int i = 0, count = children.Count; i < count; ++i)
            {
                var child = children[i];//и здесь
                if (child == null)
                { continue; }
                bool isVisible = child.IsVisible;

                if (isVisible && !hasVisibleChild)
                {
                    hasVisibleChild = true;
                }
                child.Measure(layoutSlotSize);
                Size childDesiredSize = child.DesiredSize;
                if (fHorizontal)
                {
                    desiredSize = desiredSize.WithWidth(desiredSize.Width + (isVisible ? spacing : 0) + childDesiredSize.Width);
                    desiredSize = desiredSize.WithHeight(Math.Max(desiredSize.Height, childDesiredSize.Height));
                }
                else
                {
                    desiredSize = desiredSize.WithWidth(Math.Max(desiredSize.Width, childDesiredSize.Width));
                    desiredSize = desiredSize.WithHeight(desiredSize.Height + (isVisible ? spacing : 0) + childDesiredSize.Height);
                }
            }
            if (fHorizontal)
            {
                desiredSize = desiredSize.WithWidth(desiredSize.Width - (hasVisibleChild ? spacing : 0));
            }
            else
            {
                desiredSize = desiredSize.WithHeight(desiredSize.Height - (hasVisibleChild ? spacing : 0));
            }
            return DesiredSize;
        }
      
        protected override Size ArrangeOverride(Size finalSize)
        {
            var children = Children;
            bool fHorizontal = (Orientation == Orientation.Horizontal);
            Rect rcChild = new Rect(finalSize);
            double previousChildSize = 0.0;
            var spacing = Spacing;
            //
            // Arrange and Position Children.
            //
            for (int i = 0, count = children.Count; i < count; ++i)
            {
                var child = children[i];

                if (child == null || !child.IsVisible)
                { continue; }

                if (fHorizontal)
                {
                    rcChild = rcChild.WithX(rcChild.X + previousChildSize);
                    previousChildSize = child.DesiredSize.Width;
                    rcChild = rcChild.WithWidth(previousChildSize);
                    rcChild = rcChild.WithHeight(Math.Max(finalSize.Height, child.DesiredSize.Height));
                    previousChildSize += spacing;
                }
                else
                {
                    rcChild = rcChild.WithY(rcChild.Y + previousChildSize);
                    previousChildSize = child.DesiredSize.Height;
                    rcChild = rcChild.WithHeight(previousChildSize);
                    rcChild = rcChild.WithWidth(Math.Max(finalSize.Width, child.DesiredSize.Width));
                    previousChildSize += spacing;
                }
                ArrangeChild(child, rcChild, finalSize, Orientation);
            }

            return finalSize;
        }

        internal virtual void ArrangeChild(
          IControl child,
          Rect rect,
          Size panelSize,
          Orientation orientation)
        {
            child.Arrange(rect);
        }
        public MyPanel()
    {
        AffectsMeasure<MyPanel>(SpacingProperty);
        AffectsMeasure<MyPanel>(OrientationProperty);
        InitializeComponent();

        }
    }



   
}
