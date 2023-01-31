using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelControlTest1.Models
{
    internal class AxiOMAAction : IAxiOMAAction
    {
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                if (StateChanged != null)
                    StateChanged(this, EventArgs.Empty);
            }
        }

        public string CommonText
        {
            get { return _commonText; }
            set
            {
                _commonText = value;
                if (StateChanged != null)
                    StateChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler StateChanged;

        public void Activate()
        {
            if (this._activator != null)
            {
                if (_activator(this))
                    if (StateChanged != null)
                        StateChanged(this, EventArgs.Empty);
            }
        }

        public void SetActivator(Func<IAxiOMAAction, bool> activator)
        {
            this._activator = activator;
        }

        private Func<IAxiOMAAction, bool> _activator;
        private bool _enabled = false;
        private string _commonText = string.Empty;
    }
}
