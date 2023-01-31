using Avalonia.Controls;
using PanelControlTest1.Models;
using PanelControlTest1.Views;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Windows.Input;
using static Avalonia.OpenGL.GlInterface;

namespace PanelControlTest1.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
       

        ViewModelBase content;
        public bool? visibleStart = true;
        public bool? enableStart = true;
        public bool? visibleAuto = false;
        public bool? enableAuto = false;

        //Видимость кнопок
        public bool VisibleAutoPanel
        {
            get => (bool)visibleAuto;
            set => this.RaiseAndSetIfChanged(ref visibleAuto, value);
        }
        public bool EnableAutoPanel
        {
            get => (bool)enableAuto;
            set => this.RaiseAndSetIfChanged(ref enableAuto, value);
        }
        public bool VisibleStartPanel
        {
            get => (bool)visibleStart;
            set => this.RaiseAndSetIfChanged(ref visibleStart, value);
        }
        public bool EnableStartPanel
        {
            get => (bool)enableStart;
            set => this.RaiseAndSetIfChanged(ref enableStart, value);
        }
        public void Auto()
        {
            if (VisibleAutoPanel == false)
            {
                VisibleAutoPanel = true;
            }
            if (EnableAutoPanel == false)
            {
                EnableAutoPanel = true;
            }
            VisibleStartPanel = false;
            EnableStartPanel = false;
        }
        public void Back()
        {
            if (VisibleStartPanel == false)
            {
                VisibleStartPanel = true;
            }

            if (EnableStartPanel == false)
            {
                EnableStartPanel = true;
            }
            VisibleAutoPanel = false;
            EnableAutoPanel = false;
        }

        public void Calc() //!!!НЕ БУДЕТ РАБОТАТЬ НА ЛИНУКСЕ ЕСТЕСТВЕННО, нужно что то универсальное, это в конце сделаю, так для теста
        {
            Process.Start("C:/Windows/system32/win32calc.exe");
        }

        public MainWindowViewModel()
        {
           
           
            AutoCommand = ReactiveCommand.Create(Auto);
            StartCommand = ReactiveCommand.Create(Back);
            StartCommand = ReactiveCommand.Create(Auto);
            CalcCommand = ReactiveCommand.Create(Calc);

        }

        public ReactiveCommand<Unit, Unit> AutoCommand { get; }
        public ReactiveCommand<Unit, Unit> StartCommand { get; }
        public ReactiveCommand<Unit, Unit> CalcCommand { get; }
        //       public ReactiveCommand<Unit, Unit> DisableButtons { get; }


        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public PanelControlListViewModel List { get; set; }


     

    }
    
}

