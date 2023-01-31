using Avalonia;
using Avalonia.Controls;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PanelControlTest1.MyControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelControlTest1.Models
{
    public class PanelItem : UserControl
    {

        public string? FirstText { get; set; }
        public string? SecondText { get; set; }

       

        //public bool IsChecked { get; set; }

    }
}
