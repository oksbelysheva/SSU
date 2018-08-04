using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T> where T : IComparable
    {
        public CycledDynamicArray(int length) : base(length)
        {
        }

        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(IEnumerable<T> collections) : base(collections)
        {
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
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
                    this.position++;
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
