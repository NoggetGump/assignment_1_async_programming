using System;
using System.Linq;
using System.Threading;

namespace assignments.ThreadsAssignment
{
    public class Threads
    {
        public static void Run()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int next = rnd.Next(-50, 50);

                Thread thread = new Thread(() => 
                {
                    try
                    {
                        RunInsideThreadNoOfTimes(next);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                })
                {
                    IsBackground = false
                };
                thread.Start();
            }
        }

        ///<summary>
        /// Run this in parallel! --> make sure to catch exceptions here!
        ///</summary>
        private static void RunInsideThreadNoOfTimes(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"cannot calculate with a negative number:[{number}]");
            }

            string sqRoot = Math.Sqrt((double)number).ToString();
            System.Console.WriteLine($"square root is [{sqRoot}]");
        }
    }
}