using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_GenericTypes.StorageItems
{
    public class Fruit
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Fruit f)
            {
                if (this.Name == f.Name && this.Weight == f.Weight)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Fruit: {Name}, {Weight} kg";
        }
    }
}
