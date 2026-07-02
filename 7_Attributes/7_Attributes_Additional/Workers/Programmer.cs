using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional.Workers
{

    [AccessLevel(AccessLevel.Medium)]
    internal class Programmer : Employee
    {
        public Programmer(string name) : base(name) { }
    }
}
