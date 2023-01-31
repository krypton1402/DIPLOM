using PanelControlTest1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanelControlTest1.Services;
namespace PanelControlTest1.ViewModels
{
    public class PanelControlListViewModel : ViewModelBase
    {

        public PanelControlListViewModel(IEnumerable<PanelItem> items)
        {
            Buttons = new ObservableCollection<PanelItem>(items);

        }

        public ObservableCollection<PanelItem> Buttons { get; }
        
    }
}
