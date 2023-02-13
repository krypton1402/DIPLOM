using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PanelControlTest1.ViewModels;
using PanelControlTest1.Views;
namespace PanelControlTest1
{
    public partial class App : Application
    {
        
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                

                desktop.MainWindow = new MainWindow()
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            
        }
    }
}
