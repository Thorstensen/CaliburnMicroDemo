using Caliburn.Micro.Demo.Companies.Module;
using Caliburn.Micro.Demo.Contracts;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IEventAggregator _aggregator;

        public ShellViewModel(IContent content, IEventAggregator aggregator)
        {
            Content = content;
            _aggregator = aggregator;
        }

        public void AddCompany()
        {
            _aggregator.PublishOnUIThread(new AddItemEvent("Company 1"));
        }

        private object _content;
        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyOfPropertyChange(() => Content);
            }
        }

        
    }
}
