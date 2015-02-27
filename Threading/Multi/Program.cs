using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Multi

{
    class Program
    {
        private static int counter = 0;
//        private static object counterLock = new object();

        private static object someobject = new object();
        private static object someobjectLocker = new object();

        static AutoResetEvent arE = new AutoResetEvent(false);
        static AutoResetEvent arE2 = new AutoResetEvent(false);

        private static void Main(string[] args)
        {
            Console.WriteLine("Starting main app");

            Thread t1 = new Thread(threadProc);
            // Thread t2 = new Thread(threadProc); (using the same signal across 2 threads)
            Thread t2 = new Thread(threadProc2);    // using it's own signal
            t1.Start();
            t2.Start();

            // wait for the same signal twice
            //while (!arE.WaitOne(100))
            //{
            //    Console.Write("#");
            //}
            //while (!arE.WaitOne(100))
            //{
            //    Console.Write("#");
            //}

            // wait for all signals to be fired.
            while (! WaitHandle.WaitAny(new WaitHandle[] {arE, arE2}, 100))
            {
                Console.Write("#");
            }

            Console.WriteLine( "Finished main app {0}", counter );

        }

        static void threadProc()

        {
            

           for (int x = 0; x < 100; x++)
           {
               Interlocked.Increment(ref counter);
               Thread.Sleep(10);
               //lock (counterLock) {
               // counter++;
               //}

               // turns into:
               //Monitor.Enter(counterLock);
               //try
               //{
               //    counter++;
               //}
               //finally
               //{
               //    Monitor.Exit(counterLock);
               //}
           }

            arE.Set();
        }

        static void threadProc2()
        {
            if (someobject == null)
            {
                lock (someobject) {
                someobject = new object();
                }
            }
            // simulate some work.
            Thread.Sleep(1000);

            arE2.Set();
        }
    }
}
