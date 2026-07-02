using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional.Workers
{
    [AccessLevel(AccessLevel.Low)]
    internal class Manager : Employee
    {
        public Manager(string name) : base(name) { }
    }
}
