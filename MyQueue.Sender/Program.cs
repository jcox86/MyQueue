using System;
using System.Threading;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Sender
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
                bus.Send("my.queue", new OkMessage());
                bus.Send("my.queue", new ReallyAwesomeMessage("happy path!!!"));
                
                // uncomment the next line to see what happens if there is no receiver for a message type
                // the message and and exception will be logged to the default easynetq error queue
                //bus.Send("my.queue", new object());

                Thread.Sleep(1000);
            } while (_running);
        }
    }
}
