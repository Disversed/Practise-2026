using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_GenericTypes.StorageItems
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is Book b)
            {
                if (this.Title == b.Title && this.Author == b.Author)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Book: {Title}, {Author}";
        }
    }
}
