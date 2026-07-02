using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Attributes_Additional.Workers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class AccessLevelAttribute : Attribute
    {
        public AccessLevel Level { get; }

        public AccessLevelAttribute(AccessLevel level)
        {
            Level = level;
        }
    }
}
