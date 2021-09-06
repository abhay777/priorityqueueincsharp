using System;
using System.Collections.Generic;
using System.Text;

namespace app02
{
    public class HeapTest
    {
        public void TestMaxHeap()
        {
            Heap<int> minHeap = new Heap<int>(10, Comparer<int>.Default);
            minHeap.InsertElement(10);
            minHeap.InsertElement(6);
            minHeap.InsertElement(7);
            minHeap.InsertElement(4);
            minHeap.InsertElement(2);
            minHeap.InsertElement(8);
            minHeap.InsertElement(1);
            minHeap.InsertElement(3);
            minHeap.InsertElement(5);
            minHeap.InsertElement(9);

            Console.WriteLine($"Top element {minHeap.GetTopElement()}");
            while(minHeap.Count >0)
            {
                Console.WriteLine(minHeap.RemoveTopElement());
            }
        }

        public void TestMinHeap()
        {
            Heap<int> minHeap = new Heap<int>(10, Comparer<int>.Create(new Comparison<int>((int x, int y) => y.CompareTo(x))));
            minHeap.InsertElement(10);
            minHeap.InsertElement(4);
            minHeap.InsertElement(7);
            minHeap.InsertElement(4);
            minHeap.InsertElement(2);
            minHeap.InsertElement(2);
            minHeap.InsertElement(1);
            minHeap.InsertElement(3);
            minHeap.InsertElement(5);
            minHeap.InsertElement(9);

            Console.WriteLine($"Top element {minHeap.GetTopElement()}");
            while (minHeap.Count > 0)
            {
                Console.WriteLine(minHeap.RemoveTopElement());
            }
        }

        public void Test2()
        {
            // [3,3],[5,-1],[-2,4]
            int[][] points = new int[][]
            {
                new int[] {3, 3},
                new int[] {5, -1},
                new int[] {-2, 4},
            };
            int k = 2;

            Heap<int[]> pq = new Heap<int[]>(points.Length, Comparer<int[]>.Create(
            new Comparison<int[]>(
                (p1, p2) => ((p1[0] * p1[0]) + (p1[1] * p1[1])).CompareTo((p2[0] * p2[0]) + (p2[1] * p2[1]))
                                 )
        ));

            foreach (int[] point in points)
            {
                pq.InsertElement(point);
                if (pq.Count > k)
                {
                    pq.RemoveTopElement();
                }
            }

            while (pq.Count > 0)
            {
                Console.WriteLine($"[{pq.GetTopElement()[0]}, {pq.GetTopElement()[1]}]");
                pq.RemoveTopElement();
            }
        }
    }
}
