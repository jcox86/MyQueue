using System;
using System.Threading;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Publisher
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
                bus.Publish(new ReallyAwesomeMessage("this is the happy path!"));
                Thread.Sleep(200);
            } while (_running);
        }
    }
}
