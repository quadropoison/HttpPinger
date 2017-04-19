using System;
using System.Threading;
using System.Threading.Tasks;

namespace HttpPinger
{
    public static class Start
    {
        public static void Run()
        {
            Request.CancellationToken = new CancellationTokenSource();
            var task = new Task(Request.DoRequest, Request.CancellationToken.Token);

            task.Start();

            while (!task.IsCompleted)
            {
                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Escape was pressed, task cancelled. Press any key to close console.");
                    Request.CancellationToken.Cancel();
                }
            }

            Console.WriteLine("Done.");
        }
    }
}
