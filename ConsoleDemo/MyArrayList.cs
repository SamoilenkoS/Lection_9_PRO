using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleDemo
{
    public class MyArrayList : IEnumerable<int>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.5;
        private int _count;
        private int[] _array;

        public int Capacity => _array.Length;
        public int Length => _count;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set => throw new NotImplementedException();
        }

        public MyArrayList() : this(DefaultSize)
        {
        }

        public MyArrayList(int size)
        {
            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
            _array = new int[size];
        }

        public MyArrayList(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }

        public void AddBack(int itemToAdd)
        {
            if (Capacity == Length)
            {
                int[] newArray = new int[(int)(_array.Length * Coef)];
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }

            _array[_count++] = itemToAdd;
        }

        public int[] ToArray()
        {
            int[] result = new int[Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }

        public void AddFront(int itemToAdd)
        {
            if (Capacity == Length)
            {
                int[] newArray = new int[(int)(_array.Length * Coef)];

                for (int i = 1; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }

            int[] newArray2 = new int[_array.Length];

            for (int i = 1; i < _array.Length; i++)
            {
                newArray2[i] = _array[i - 1];
            }
            _array = newArray2;
            _array[0] = itemToAdd;
            _count++;
        }

        public void AddByIndex(int index, int itemToAdd)
        {
            {
                int[] newArray = new int[_array.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = _array[i];
                }

                for (int i = index + 1; i < _count + 1; i++)
                {
                    newArray[i] = _array[i - 1];
                }

                newArray[index] = itemToAdd;
                _array = newArray;
                _count++;
            }
        }

        public int RemoveBack()
        {
            int[] newArray = new int[_array.Length];

            for (int i = 0; i < _count - 1; i++)
            {
                newArray[i] = _array[i];
            }

            int deletedNumber = _array[_count - 1];
            _array = newArray;
            _count--;
            return deletedNumber;
        }

        public int RemoveFront()
        {
            int[] newArray = new int[_array.Length];

            for (int i = 1; i < _count; i++)
            {
                newArray[i - 1] = _array[i];
            }
            int deletedNumber = _array[0];
            _array = newArray;
            _count--;
            return deletedNumber;
        }

        public int RemoveByIndex(int index)
        {
            int[] newArray = new int[_array.Length];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < _count; i++)
            {
                newArray[i] = _array[i + 1];
            }

            int deletedNumber = _array[index];
            _array = newArray;
            _count--;
            return deletedNumber;
        }

        public int[] RemoveNValuesBack(int n)
        {
            int localCount = 0;
            int[] newArray = new int[_array.Length];
            int[] deletedNumbers = new int[n];
            do
            {
                if (n > 0)
                {
                    for (int i = 0; i < _count; i++)
                    {
                        newArray[i] = _array[i];
                        deletedNumbers[localCount] = _count;
                    }
                    localCount++;
                    _count--;
                    _array = newArray;
                }
            } while (localCount < n);

            return deletedNumbers;
        }

        public int[] RemoveNValuesFront(int n)
        {
            int localCount = 0;
            int[] newArray = new int[_array.Length];
            int[] deletedNumbers = new int[n];

            do
            {
                if (n > 0)
                {
                    deletedNumbers[localCount] = _array[0];

                    for (int i = 1; i < _count; i++)
                    {
                        newArray[i - 1] = _array[i];
                    }

                    localCount++;
                    _count--;
                    _array = newArray;
                }
            } while (localCount < n);
            return deletedNumbers;
        }

        public int[] RemoveNValuesByIndex(int index, int n)
        {
            int localCount = 0;
            int[] newArray = new int[_array.Length];
            int[] deletedNumbers = new int[n];

            do
            {
                if (n > 0)
                {
                    deletedNumbers[localCount] = _array[index];


                    for (int i = 0; i < index; i++)
                    {
                        newArray[i] = _array[i];
                    }

                    for (int i = index; i < _count; i++)
                    {
                        newArray[i] = _array[i + 1];
                    }

                    localCount++;
                    _count--;
                    _array = newArray;
                }

            } while (localCount < n);

            return deletedNumbers;
        }

        public int IndexOf(int element)
        {
            int result = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == element)
                {
                    result = i;
                    break;
                }
                else
                {
                    result = -1;
                }
            }

            return result;
        }

        public void Reverse()
        {
            if (_array == null)
            {
                throw new ArgumentException();
            }

            int count = 1;
            int[] newArray = new int[_array.Length];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[_count - count];
                count++;
            }
            _array = newArray;
        }

        public int Max()
        {
            if (_array == null)
            {
                throw new ArgumentException();
            }

            int maxIndex = 0;
            int maxElement;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            maxElement = _array[maxIndex];
            return maxElement;
        }

        public int Min()
        {
            if (_array == null)
            {
                throw new ArgumentException();
            }

            int minIndex = 0;
            int minElement;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }
            minElement = _array[minIndex];
            return minElement;
        }

        public int MaxIndex()
        {
            if (_array == null)
            {
                throw new ArgumentException();
            }

            int maxIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int MinIndex()
        {
            if (_array == null)
            {
                throw new ArgumentException();
            }

            int minIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void Sort(bool ascending = true)
        {
            if (ascending == true)
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    int minIndex = i;

                    for (int j = i + 1; j < _count; j++)
                    {
                        if (_array[j] < _array[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    if (minIndex != i)
                    {
                        Swap(ref _array[i], ref _array[minIndex]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    int maxIndex = i;

                    for (int j = i + 1; j < _count; j++)
                    {
                        if (_array[j] > _array[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }

                    if (maxIndex != i)
                    {
                        Swap(ref _array[i], ref _array[maxIndex]);
                    }
                }
            }
        }

        public int RemoveByValue(int value)
        {
            int[] newArray = new int[_array.Length];
            int indexOfElement = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i] == value)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    break;
                }
                else
                {
                    indexOfElement = -1;
                }
            }
            return indexOfElement;
        }

        public int RemoveByValueAll(int value)
        {
            int[] newArray = new int[_array.Length];
            int indexOfElement;
            int countOfElements = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i] == value)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    i--;
                    countOfElements++;
                }
                else if (_array[0] == value)
                {
                    countOfElements++;
                    break;
                }
            }
            if (countOfElements == 0)
            {
                countOfElements = -1;
            }
            return countOfElements;
        }

        public void AddFront(IEnumerable<int> items)
        {
            int localCount = 0;

            foreach (int item in items)
            {
                localCount++;
                _count++;
            }

            int[] newArray2 = new int[_array.Length + localCount];
            int i = 0;

            foreach (int item in items)
            {
                newArray2[i++] = item;
            }

            foreach (int item in _array)
            {
                newArray2[i++] = item;
            }

            _array = newArray2;
        }

        public void AddBack(IEnumerable<int> items)
        {
            int localCount = 0;

            foreach (int item in items)
            {
                localCount++;
            }

            int[] newArray2 = new int[_array.Length + localCount];
            int i = 0;

            for (int j = 0; j < _count; j++)
            {
                newArray2[j] = _array[j];
                i++;
            }

            foreach (int item in items)
            {
                newArray2[i++] = item;
                _count++;
            }

            _array = newArray2;
        }

        public void AddByIndex(int index, IEnumerable<int> items)
        {
            int localCount = 0;

            foreach (int item in items)
            {
                localCount++;
            }

            int[] newArray2 = new int[_array.Length + localCount];
            int i = 0;

            for (int j = 0; j < index; j++)
            {
                newArray2[j] = _array[j];
                i++;
            }

            foreach (int item in items)
            {
                newArray2[i++] = item;
                _count++;
            }

            for (int j = i; j < _count; j++)
            {
                newArray2[j] = _array[index];
                index++;
            }

            _array = newArray2;
        }

        private static (int, int) Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            return (a, b);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
