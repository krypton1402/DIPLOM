using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelControlTest1.Models
{
    public interface IAxiOMAAction
    {
        void Activate();
        void SetActivator(Func<IAxiOMAAction, bool> activator);
        event EventHandler StateChanged;
        bool Enabled { get; set; }
        string CommonText { get; set; }
    }
}
