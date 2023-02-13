using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Windows.Input;
using PcNcCommon;
using PcNcCommClient;

namespace PanelControlTest1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       

        ViewModelBase content;
        public bool? visibleStart = true;
        public bool? enableStart = true;
        public bool? visibleAuto = false;
        public bool? enableAuto = false;
        public bool? enableConn = true;


        //NC values NC - is the client my application connects to and where the data comes from

        CoordClass cl = new CoordClass();

        // We need a public accessor to cl
        public CoordClass CL => cl; 
        
        //Button visibility
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
        public bool EnableConnect
        {
            get => (bool)enableConn;
            set => this.RaiseAndSetIfChanged(ref enableConn, value);
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
                //cl.Timer_Tick();
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

        public void Calc() //!!!ÍÅ ÁÓÄÅÒ ÐÀÁÎÒÀÒÜ ÍÀ ËÈÍÓÊÑÅ ÅÑÒÅÑÒÂÅÍÍÎ, íóæíî ÷òî òî óíèâåðñàëüíîå, ýòî â êîíöå ñäåëàþ, òàê äëÿ òåñòà//IT WON'T WORK ON LINUX, OF COURSE, you need something universal, I'll do it in the end, so for the test
        {
            Process.Start("C:/Windows/system32/win32calc.exe");
        }

        public MainWindowViewModel()
        {
            ConnectCommand = ReactiveCommand.Create(Connect);
            BackCommand = ReactiveCommand.Create(Back);


            AutoCommand = ReactiveCommand.Create(Auto);
            StartCommand = ReactiveCommand.Create(Back);
            CalcCommand = ReactiveCommand.Create(Calc);
            //ConnectCommand = ReactiveCommand.Create(Connect);

        }

        public ReactiveCommand<Unit, Unit> AutoCommand { get; }
        public ReactiveCommand<Unit, Unit> StartCommand { get; }
        public ReactiveCommand<Unit, Unit> CalcCommand { get; }
        //public ReactiveCommand<Unit, Unit> ConnectCommand { get; }
        //       public ReactiveCommand<Unit, Unit> DisableButtons { get; }


        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        private void Connect()
        {

            cl.Connecting();
        }

        public ICommand ConnectCommand { get; }
        public ICommand BackCommand { get; }










    }
    
}

