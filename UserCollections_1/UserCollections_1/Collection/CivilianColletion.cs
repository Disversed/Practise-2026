using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections_1.Collection
{
    internal class CivilianCollection : IEnumerable<Civilian>
    {
        private Civilian[] arr;
        public int Count { get; private set; } = 0;
        public int Capacity { get { return arr.Length; } }

        public CivilianCollection() : this(4) { }

        public CivilianCollection(int size)
        {
            if (size < 0) throw new Exception("Collection size must be a non-negative value");
            arr = new Civilian[size];
        }

        public int Add(Civilian civ)
        {
            if (civ == null) return -1;

            // Проверка на дубликаты
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(civ))
                {
                    Console.WriteLine($"A civilian with the passport ID #{civ.PassportID} is already in queue");
                    return -1;
                }
            }

            // Расширение массива, если он заполнен
            if (Count == Capacity)
            {
                Resize(Capacity == 0 ? 4 : Capacity * 2);
            }

            int targetIndex;

            if (civ is Pensioner) // Логика для Pensioner
            {
                targetIndex = 0;
                while (targetIndex < Count && arr[targetIndex] is Pensioner)
                {
                    targetIndex++;
                }

                Array.Copy(arr, targetIndex, arr, targetIndex + 1, Count - targetIndex);
                arr[targetIndex] = civ;
            }
            else // Логика для остальных
            {
                targetIndex = Count;
                arr[targetIndex] = civ;
            }

            Count++;
            return targetIndex;
        }

        public void RemoveFirst()
        {
            if (Count == 0) return;

            Array.Copy(arr, 1, arr, 0, Count - 1);
            Count--;
            arr[Count] = null;
        }

        public void Remove(Civilian civ)
        {
            Contains(civ, out int index);
            if (index == -1) return;

            Array.Copy(arr, index + 1, arr, index, Count - index - 1);
            Count--;
            arr[Count] = null;
        }

        public bool Contains(Civilian civ, out int index)
        {
            index = -1;
            if (civ == null) return false;

            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(civ))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public Civilian ReturnLast(out int index)
        {
            index = -1;
            if (Count == 0) return null;

            index = Count - 1;
            return arr[index];
        }

        public void Clear()
        {
            Array.Clear(arr, 0, Count);
            Count = 0;
        }

        private void Resize(int newSize)
        {
            Civilian[] newArr = new Civilian[newSize];
            Array.Copy(arr, newArr, Count);
            arr = newArr;
        }

        public IEnumerator<Civilian> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
