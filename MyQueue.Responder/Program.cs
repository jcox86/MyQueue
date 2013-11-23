using System;
using System.Threading.Tasks;
using EasyNetQ;
using MyQueue.Contract;

namespace MyQueue.Responder
{
    class Program
    {
        private static bool _running;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            Console.CancelKeyPress += delegate { _running = false; };

            _running = true;

            bus.RespondAsync<ReallyAwesomeRequest, ReallyAwesomeResponse>(request =>
                  Task.Factory.StartNew(() =>
                  {
                      return new ReallyAwesomeResponse { RightBackAtcha = "ooo la la" };
                  }));

            do
            {
            } while (_running);
        }
    }
}
