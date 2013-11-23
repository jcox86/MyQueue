using System;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Subscriber2
{
    class Program
    {
        private static bool _running;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            bus.Subscribe<ReallyAwesomeMessage>("MyQueue.Subscriber2", x => Console.WriteLine(x.SuperDuper));

            Console.CancelKeyPress += delegate { _running = false; };

            _running = true;

            do
            {
            } while (_running);
        }
    }
}
