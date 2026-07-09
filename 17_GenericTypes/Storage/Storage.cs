using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_GenericTypes.Storage
{
    public class Storage<T> where T : class
    {
        private List<T> items = new List<T>();

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public bool RemoveItem(T item)
        {
            return items.Remove(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(items);
        }
    }
}
