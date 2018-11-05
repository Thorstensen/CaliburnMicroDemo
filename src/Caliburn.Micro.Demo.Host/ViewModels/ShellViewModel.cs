using Caliburn.Micro.Demo.Companies.Module;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Shopping.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using System.Linq;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IEventAggregator _aggregator;

        public ShellViewModel(IEventAggregator aggregator, IEnumerable<IStore> stores)
        {
            _aggregator = aggregator;
            Stores = new ObservableCollection<IStore>(stores);
        }

        private ObservableCollection<IStore> _stores;
        public ObservableCollection<IStore> Stores
        {
            get { return _stores; }
            set
            {
                _stores = value;
                NotifyOfPropertyChange(() => Stores);
            }
        }
    }
}
