using System;
using System.Threading;

namespace Multithreading
{
    public class SuperPuperThreads
    {
        static void Main(string[] args)
        {
            
            Thread thr1 = new Thread(() => { ProcessData(0, 9, 10, "Thread 1"); });
            Thread thr2 = new Thread(() => { ProcessData(0, 9, 10, "Thread 2"); });

            thr1.Start();
            thr2.Start();

            
            thr1.Join();
            thr2.Join();

            Console.WriteLine("All data processing complete.");
        }

        
        public static int[] GetRandomArray(int arrLength)
        {
            var arr = new int[arrLength];
            Random rnd = new Random();

            for (int i = 0; i < arrLength; i++)
            {
                arr[i] = rnd.Next(1, 10);
            }

            return arr;
        }

    
        public static void ProcessData(int start, int end, int arrLength, string threadName)
        {
            int[] arr = GetRandomArray(arrLength);


            Console.WriteLine($"{threadName} started processing data.");

            for (int i = start; i <= end; i++)
            {
                arr[i] *= 2;
                Console.WriteLine($"{threadName} processed element {i}: {arr[i]}");
                Thread.Sleep(500); 
            }

           

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }


            Console.WriteLine($"\n{threadName} processing complete.");
            Console.WriteLine($"\n----------------------------------------------");
        }
    }
}
