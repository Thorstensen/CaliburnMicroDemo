using Caliburn.Micro.Demo.Companies.Module;
using Caliburn.Micro.Demo.Contracts;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public ShellViewModel(IContent content)
        {
            Content = content;
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
