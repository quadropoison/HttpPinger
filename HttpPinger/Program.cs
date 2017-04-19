using System;

namespace HttpPinger
{
    class Program
    {
        private static bool errorPresent;
        static void Main(string[] args)
        {
            Console.WriteLine("Type valid url to request : " + "\n");

            errorPresent = true;

            while (errorPresent == true)
            {
                Request.RequestUrl = Console.ReadLine();

                if (!Request.RequestUrl.Contains("http"))
                {
                    var message = "Type valid URL! \n";
                    WriteErrorMessage(message);
                }
                else
                {
                    errorPresent = false;
                }
            }

            Start.Run();
        }

        private static void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
