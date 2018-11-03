using Caliburn.Micro.Demo.Contracts;
using System.ComponentModel.Composition;

namespace Caliburn.Micro.Demo.Host.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
    }
}
