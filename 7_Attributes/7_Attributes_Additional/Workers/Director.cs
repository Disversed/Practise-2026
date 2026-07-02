using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional.Workers
{
    [AccessLevel(AccessLevel.High)]
    internal class Director : Employee
    {
        public Director(string name) : base(name) { }
    }
}
