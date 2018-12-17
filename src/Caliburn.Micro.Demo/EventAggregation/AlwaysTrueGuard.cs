using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.EventAggregation
{
    public class AlwaysTrueGuard : IExecuteGuard
    {
        public bool CanExecute(object command)
        {
            return true;
        }
    }
}
