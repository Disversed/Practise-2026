using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections_1
{
    internal abstract class Civilian
    {
        public int PassportID { get; }
        public abstract string Occupation { get; }

        protected Civilian(int passportID)
        {
            PassportID = passportID;
        }

        public override string ToString() => $"Passport ID #{PassportID}: {Occupation}";

        public override bool Equals(object obj)
        {
            if (obj is Civilian civilian)
            {
                return PassportID == civilian.PassportID;
            }
            return false;
        }
    }
}
