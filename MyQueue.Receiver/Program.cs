using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Receiver
{
    class Program
    {
        private static bool _running;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            Console.CancelKeyPress += delegate { _running = false; };

            _running = true;

            bus.Receive("my.queue", x => x
                .Add<OkMessage>(message => Console.WriteLine(message.ToString()))
                .Add<ReallyAwesomeMessage>(message => Console.WriteLine(message.SuperDuper))); 

            do
            {
            } while (_running);
        }
    }
}
