using System;
using Microsoft.Owin.Hosting;

namespace KatanaSelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            // This time because we're selfhosting we need Microsoft.owin.selfhost NOT microsoft.owin.host.systemweb

            // The WebApp .Start comes from Microsoft.Owin.Hosting, and just makes a little HttpListener
            // Uses the class we define as the Startup class (Also called our startup class here)
            // And at the url we specify as a parameter
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("Listening on port 12345, press Enter to end...");
                Console.ReadLine();
            }

            // Be aware that if you want to serve static files, you will need the package "Microsoft.Owin.StaticFiles"
            // As IIS would normally handle that for you.

            // So install it and then add it into your pipeline via x.UseStaticFiles();
        }
    }
}
