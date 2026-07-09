using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_GenericTypes.StorageItems
{
    public class Phone
    {
        public string Model { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Phone p)
            {
                if (this.Model == p.Model && this.Price == p.Price)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Phone: {Model}, {Price}";
        }
    }
}
