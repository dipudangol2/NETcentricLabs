using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AsyncTasks
    {
        public static async Task AsyncMethod()
        {
            Task<string> processTask = Process();

            Console.WriteLine("Executed. Calling asynchronous process with await..");

            string result = await processTask;
            Console.WriteLine($"{result}");
        }
        public static async Task<string> Process()
        {
            await Task.Delay(3000);
            return "Process completed after 3 seconds";

        }
    }

}
