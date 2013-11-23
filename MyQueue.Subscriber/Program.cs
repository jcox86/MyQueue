using System;
using MyQueue.Contract;
using EasyNetQ;

namespace MyQueue.Subscriber
{
    class Program
    {
        private static bool _running;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Subscribe<ReallyAwesomeMessage>("MyQueue.Subscriber", x => Console.WriteLine(x.SuperDuper));

            Console.CancelKeyPress += delegate { _running = false; };

            _running = true;

            do
            {
            } while (_running);
        }
    }
}
