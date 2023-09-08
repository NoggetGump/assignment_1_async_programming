using System;
using System.Collections.Generic;
using System.Linq;

namespace assignments
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = args.LastOrDefault();
            if (map.TryGetValue(key, out Action run))
            {
                try
                {
                    run();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"running key threw exception: {ex.Message}");
                }
            }
            else
            {
                string availableKeys = string.Join(", ", map.Keys);
                string newLine = Environment.NewLine;
                System.Console.WriteLine($"key: [{key}] not available. Try any of the following{newLine}{availableKeys}");
            }
        }

        private static Dictionary<string, Action> map = new Dictionary<string, Action>();

        static Program()
        {
            map.Add("threads", ThreadsAssignment.Threads.Run);
            map.Add("join", ThreadsAssignment.JoinThreads.Run);
        }
    }
}
