using System;
using System.Linq;
using System.Threading;

namespace assignments.ThreadsAssignment
{
    public class JoinThreads
    {
        private static bool isSignaled = false;
        public static void Run()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int next = rnd.Next(0, 1000);
                System.Console.WriteLine($"Thread {i} - calc time is [{next}] ms");
                int timeOut = 400;
                
                Thread thread = new Thread(() => 
                {
                    CalculateInThread(i, next);
                });

                isSignaled = false;

                thread.Start();

                bool joinedThread = thread.Join(timeOut);
                if(!joinedThread)
                {
                    isSignaled = true;
                    Console.WriteLine($"Thread {i} - Timed Out");
                }

                //thread.Join(); //wait the rest of the operation after the signal to end - if there is anything else (fix after watching the solution)
            }
        }

        ///<summary>
        ///Simulates long running operation work in milliseconds
        ///</summary>
        public static void CalculateInThread(int nRun, int nextCalcTimeInMs)
        {
            double divided = nextCalcTimeInMs/2.0d;
            var half = (int)Math.Floor(divided);

            Thread.Sleep(half);

            if(isSignaled)
            {
                Console.WriteLine($"Thread {nRun} - Ran halfway to the end with time equals to {half}");
            }
            else
            {
                Thread.Sleep(half);
                Console.WriteLine($"Thread {nRun} - Ran to the end with time equals to {nextCalcTimeInMs}");
            }
        }
    }
}