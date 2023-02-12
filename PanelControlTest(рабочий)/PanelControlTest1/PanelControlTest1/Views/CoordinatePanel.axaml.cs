using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using PanelControlTest1.Models;
using PcNcCommClient;
using PcNcCommon;
using System;
using System.Timers;

namespace PanelControlTest1.Views
{
    public partial class CoordinatePanel : UserControl
    {
        
        public CoordinatePanel()
        {
        
           
            
            InitializeComponent();
            DataContext = new CoordClass();
           
            
                
            
            
            
           

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        
       
    }
}
