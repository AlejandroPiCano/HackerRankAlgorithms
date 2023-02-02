using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class AsynchronousProgramming
    {
        internal static async Task TaskParallel()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            List<Task> tasksToComplete = new List<Task>() {
              Task.Run(() => { Thread.Sleep(2000); }),
              Task.Run(() => { Thread.Sleep(1000); }),
              Task.Run(() => { Thread.Sleep(3000); }),
              Task.Run(() => { Thread.Sleep(1500); }),
              Task.Run(() => { Thread.Sleep(1500); }),
              Task.Run(() => { Thread.Sleep(1500); }),
              Task.Run(() => { Thread.Sleep(1500); }),
              Task.Run(() => { Thread.Sleep(1500); }),
              Task.Run(() => { Thread.Sleep(500); }),
          };

          await  Task.WhenAny(tasksToComplete); //the lowest value 500
            
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
