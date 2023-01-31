using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelControlTest1.Models
{
    public class AxiOMAPanelEventArgs : EventArgs
    {
        public IAxiOMAAction action;
        public uint number;

        public AxiOMAPanelEventArgs(IAxiOMAAction action, uint number)
        {
            this.action = action;
            this.number = number;
        }
    }

    public class AxiOMAPanel
    {
        private uint _numButtons;
        private IAxiOMAAction[] _actions;

        public event EventHandler<AxiOMAPanelEventArgs> StateChanged;

        public AxiOMAPanel(uint numButtons)
        {
            this._numButtons = numButtons;
            _actions = new IAxiOMAAction[numButtons];
        }

        public void SetAction(uint num, IAxiOMAAction action)
        {
            if (num > (_numButtons - 1))
                throw new ArgumentOutOfRangeException("num", "Button number out of range");

            if (_actions[num] != null)
                _actions[num].StateChanged -= Action_StateChanged;

            _actions[num] = action;
            if (action != null)
            {
                action.StateChanged += Action_StateChanged;
            }
        }

        private void Action_StateChanged(object sender, EventArgs e)
        {
            if (StateChanged == null)
                return;

            for (uint index = 0; index < _numButtons; index++)
            {
                if (_actions[index] == null)
                    continue;

                if (_actions[index] == sender)
                    StateChanged(this, new AxiOMAPanelEventArgs(_actions[index], index));
            }
        }

        public IAxiOMAAction GetAction(uint num)
        {
            if (num > (_numButtons - 1))
                throw new ArgumentOutOfRangeException("num", "Button number out of range");

            return _actions[num];
        }

        public void Click(uint num)
        {
            if (num > (_numButtons - 1))
                throw new ArgumentOutOfRangeException("num", "Button number out of range");

            if ((_actions[num] != null) && (_actions[num].Enabled))
                _actions[num].Activate();
        }

        public uint NumButtons { get { return _numButtons; } }
    }
}
