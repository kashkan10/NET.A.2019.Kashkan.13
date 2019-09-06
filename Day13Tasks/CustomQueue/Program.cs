using System;
using System.Linq;

namespace CustomQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(9);
            que.Enqueue(7);

            foreach (int n in que)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            Console.WriteLine($"Count of elements {que.Count()}");
            que.Dequeue();
            Console.WriteLine($"Count of elements {que.Count()}");
            que.Peek();
            Console.WriteLine($"Count of elements {que.Count()}");
            Console.WriteLine();

            Console.WriteLine(que.Contains(9));

            foreach (int n in que)
            {
                Console.WriteLine(n);
            }

            Console.Read();
        }
    }
}
