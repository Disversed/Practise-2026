using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections_1
{
    internal class Pensioner : Civilian
    {
        public override string Occupation { get; } = "Pensioner";
        public Pensioner(int passportID) : base(passportID) { }
    }
}
