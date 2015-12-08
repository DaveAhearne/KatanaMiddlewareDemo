using System;
using Nancy.Hosting.Self;

namespace MoreNancyFxSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is similar to the OwinSelfhosting we've seen before (It calls stop on dispose)
            using (var host = new NancyHost(new Uri("http://localhost:12345")))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }
}
