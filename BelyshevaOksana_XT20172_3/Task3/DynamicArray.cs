using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable where T : IComparable
    {
        private T[] array;
        private int length = 0;

        public DynamicArray()
        {
            this.array = new T[8];
        }

        public DynamicArray(int length)
        {
            this.array = new T[length];
        }

        public DynamicArray(IEnumerable<T> collections)
        {
            this.AddRange(collections);
        }

        public int Capacity
        {
            get
            {
                if (this.array == null)
                {
                    return 0;
                }

                return this.array.Length;
            }

            set
            {
                this.ExpansionCapacity(value);
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (index >= 0)
                {
                    return this.array[index];
                }
                else
                {
                    return this.array[this.Length + index];
                }
            }

            set
            {
                if (index >= 0)
                {
                    this.array[index] = value;
                }
                else
                {
                    this.array[this.Length - 1] = value;
                }
            }
        }

        public void Add(T element)
        {
            this.length++;
            if (this.Length > this.Capacity)
            {
                this.Capacity = this.Capacity * 2;
            }

            this.array[this.length - 1] = element;
        }

        public void AddRange(IEnumerable<T> collections)
        {
            if (collections == null)
            {
                return;
            }

            int pos = this.length;
            this.length += collections.Count();
            if (this.Length > this.Capacity)
            {
                this.Capacity = this.Capacity + (this.Length - this.Capacity);
            }

            foreach (var item in collections)
            {
                this.array[pos] = item;
                pos++;
            }
        }

        public bool Remove(T element)
        {
            bool deleted = false;
            for (int i = 0; i < this.Length; i++)
            {
                if (element.CompareTo(this.array[i]) == 0)
                {
                    deleted = true;
                    this.SlideLeft(i);
                    i--;
                    this.length--;
                    break;
                }
            }

            return deleted;
        }

        public bool Insert(int pos, T value)
        {
            if (pos > this.Length || pos < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Capacity < this.Length + 1)
            {
                this.Capacity = this.Capacity * 2;
            }

            this.SlideRight(pos);
            this.array[pos] = value;
            this.length++;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public object Clone()
        {
            DynamicArray<T> other = new DynamicArray<T>(this.Capacity);
            other.AddRange(this.array);
            other.length = this.Length;
            return other;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                array[i] = this.array[i];
            }

            return array;
        }

        private void ExpansionCapacity(int value)
        {
            T[] newArray = new T[value];
            if (this.array != null)
            {
                Array.Copy(this.array, newArray, (this.array.Length < value) ? this.array.Length : value);
            }

            this.array = newArray;
            if (this.Capacity < this.Length)
            {
                this.length = value;
            }
        }

        private void SlideLeft(int i)
        {
            for (int j = i; j < this.Length - 1; j++)
            {
                this.array[j] = this.array[j + 1];
            }
        }

        private void SlideRight(int pos)
        {
            for (int j = this.Length; j > pos; j--)
            {
                this.array[j] = this.array[j - 1];
            }
        }

        private class Enumerator<T2> : IEnumerator<T2> where T2 : IComparable
        {
            private int position = -1;
            private DynamicArray<T2> dynamicArray;

            internal Enumerator(DynamicArray<T2> dynamicArray)
            {
                this.dynamicArray = dynamicArray;
            }

            public T2 Current
            {
                get
                {
                    try
                    {
                        return this.dynamicArray[this.position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    try
                    {
                        return this.dynamicArray[this.position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.position++;
                if (this.position >= this.dynamicArray.Length)
                {
                    this.Reset();
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}
