using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo
{
    public class AddItemEvent
    {
        public AddItemEvent(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
