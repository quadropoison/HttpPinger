using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpPinger
{
    public static class Request
    {
        public static CancellationTokenSource CancellationToken { get; set; }

        public static string RequestUrl { get; set; }

        public static void DoRequest()
        {
            HttpClient client = new HttpClient();

            while (!CancellationToken.IsCancellationRequested)
            {
                Task<HttpResponseMessage> requestTask = client.GetAsync(RequestUrl);
                HttpResponseMessage responseMessage = requestTask.Result;

                SetUrlStringOutputColor(RequestUrl);

                Console.WriteLine(responseMessage.Headers);

                SetStatusCodeOutputColor(responseMessage);

                Console.WriteLine(responseMessage.StatusCode + "\n");
                Console.ResetColor();

                Thread.Sleep(1000);
            }
        }

        private static void SetStatusCodeOutputColor(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void SetUrlStringOutputColor(string requestUrl)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(requestUrl);
            Console.ResetColor();
        }
    }
}
