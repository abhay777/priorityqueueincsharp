using System;
using System.Collections.Generic;
using System.Text;

namespace app02
{
    public class Heap<T>
    {
        private T[] array;
        private int capacity;
        public int Count { get; set; }
        private Comparer<T> Comparer;

        public Heap(int capacity, Comparer<T> comparer)
        {
            this.capacity = capacity;
            this.array = new T[this.capacity];
            this.Count = 0;
            this.Comparer = comparer;
        }

        public int GetParent(int i)
        {
            if (i <= 0 || i >= this.Count)
                return -1;

            return (i - 1) / 2;
        }

        public int GetLeftChild(int i)
        {
            int left = i * 2 + 1;
            if (left >= this.Count)
                return -1;

            return left;
        }

        public int GetRightChild(int i)
        {
            int right = i * 2 + 2;
            if (right >= this.Count)
                return -1;
            return right;
        }

        // for min heap it will return min element.
        // for max heap it will return max element.
        public T GetTopElement()
        {
            if (this.Count == 0)
                return default(T);

            return this.array[0];
        }

        public void PercolateDown(int i)
        {
            int left, right, max;
            T temp;
            left = GetLeftChild(i);
            right = GetRightChild(i);

            if (left != -1 && this.Comparer.Compare(this.array[left], this.array[i]) >= 0)
                max = left;
            else
                max = i;

            if (right != -1 && this.Comparer.Compare(this.array[right], this.array[max]) >= 0)
                max = right;

            if (max != i)
            {
                temp = this.array[i];
                this.array[i] = this.array[max];
                this.array[max] = temp;
                PercolateDown(max);
            }
        }

        public void PercolateUp(int i)
        {
            if (i <= 0) return;

            int parent = this.GetParent(i);

            if (i >= 0 && this.Comparer.Compare(this.array[i], this.array[parent])>=0)
            {
                T temp = this.array[parent];
                this.array[parent] = this.array[i];
                this.array[i] = temp;
                PercolateUp(parent);
            }
        }

        public T RemoveTopElement()
        {
            if (this.Count == 0)
                return default(T);

            T data = this.array[0];
            this.array[0] = this.array[this.Count - 1];
            this.Count -= 1;
            PercolateDown(0);
            return data;
        }

        public void InsertElement(T data)
        {
            int i;
            if (this.Count >= this.capacity)
                throw new ArgumentException("Capacity limit reached.");
            
            this.Count++;
            i = this.Count - 1;
            this.array[i] = data;
            PercolateUp(i);
        }
    }
}
