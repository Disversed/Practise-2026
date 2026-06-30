using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections_1
{
    internal class Worker : Civilian
    {
        public override string Occupation { get; } = "Worker";
        public Worker(int passportID) : base(passportID) { }
    }
}
