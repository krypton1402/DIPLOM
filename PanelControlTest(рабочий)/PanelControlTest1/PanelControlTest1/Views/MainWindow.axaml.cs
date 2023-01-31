using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using PanelControlTest1.Models;
using PanelControlTest1.Services;
using PanelControlTest1.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;

namespace PanelControlTest1.Views
{
    public partial class MainWindow : Window
    {
        Database db;
        
        public PanelControlListViewModel List { get; }
        public MainWindow()
        {db = new Database();
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

            void timer_Tick(object sender, EventArgs e)
            {
                LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
                LiveDateLabel.Content = DateTime.Now.ToString("dd/MM/yyyy");
            }
#if DEBUG
            this.AttachDevTools();
#endif
            this.DataContext = this;
            
        }
        
    }
}
