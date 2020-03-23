using System;
using System.Threading;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace Laborator1
{
    class Program
    {
        static ConcurrentQueue<string> cq = new ConcurrentQueue<string>();

        public static void Prime1(object data)
        {
            int threshold = (int)data;
            cq.Enqueue("Start fir: " + Thread.CurrentThread.Name + " -- " + DateTime.Now.ToString("hh:mm:ss:ms") + " -- Numar natural dat = " + threshold.ToString());

            int Result = 0;
            bool IsPrime;

            for (int Number = 2; Number <= threshold; Number++)
            {
                IsPrime = true;
                for(int d = 2; d < Number; d++)
                {
                    if (Number % d == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }

                if(IsPrime)
                    Result = Number;
            }

            cq.Enqueue("End fir: " + Thread.CurrentThread.Name + " -- " + DateTime.Now.ToString("hh:mm:ss:ms") + " -- Numar prim = " + Result.ToString());
        }

        public static void Prime2(object data)
        {
            int threshold = (int)data;
            cq.Enqueue("Start fir: " + Thread.CurrentThread.Name + " -- " + DateTime.Now.ToString("hh:mm:ss:ms") + " -- Numar natural dat = " + threshold.ToString());

            int Result;
            bool IsPrime;

            if (threshold >= 2)
                Result = 2;
            else
                Result = 0;

            for (int Number = 3; Number <= threshold; Number++)
            {
                if (Number % 2 == 0)
                    continue;

                IsPrime = true;
                for (int d = 3; d <= Math.Sqrt(Number); d += 2)
                {
                    if(Number % d == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }

                if (IsPrime)
                    Result = Number;

            }

            cq.Enqueue("End fir: " + Thread.CurrentThread.Name + " -- " + DateTime.Now.ToString("hh:mm:ss:ms") + " -- Numar prim = " + Result.ToString());
        }

        public static void RawThreads()
        {
            Thread Thread1 = new Thread(new ParameterizedThreadStart(Prime1));
            Thread Thread2 = new Thread(new ParameterizedThreadStart(Prime2));

            Thread1.Name = "Prime1";
            Thread2.Name = "Prime2";

            Thread1.Start(100);
            Thread2.Start(100);

            Console.WriteLine("Threads started.. Waiting for result.");
            Thread1.Join();
            Thread2.Join();

            foreach(var message in cq)
            {
                Console.WriteLine(message);
            }
        }

        static void Main(string[] args)
        {
            RawThreads();
        }
    }
}
