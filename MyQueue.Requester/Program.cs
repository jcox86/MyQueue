using System;
using System.Threading;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Requester
{
    class Program
    {
        private static bool _running;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            Console.CancelKeyPress += delegate { _running = false; };

            _running = true;

            do
            {
                var task = bus.RequestAsync<ReallyAwesomeRequest, ReallyAwesomeResponse>(new ReallyAwesomeRequest{GimmeSomeLove = "please!"});
                task.ContinueWith(response => Console.WriteLine(response.Result))
                    .Wait(TimeSpan.FromSeconds(5));
                Thread.Sleep(500);
            } while (_running);
        }
    }
}
