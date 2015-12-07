using System;
using System.Diagnostics;
using KatanaMiddlewareOptions.Middleware;
using Owin;

namespace KatanaMiddlewareOptions
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            /*
             * But how do we externally configure our middleware without digging into code?:
             * We add an options class, its the name of the middleware + options 
             */

            //app.Use<DebugMiddleware>();

            // Now because we've said our debug middlewares needs an options class, we need to provide it one when we instantiate it:
            app.Use<DebugMiddleware>(new DebugMiddlewareOptions
            {
                // See now how we can change it into a perfmon tool:
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();

                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutGoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];

                    watch.Stop();

                    Debug.WriteLine("Request completed in: " + watch.ElapsedMilliseconds);
                },
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Now we've moved into middleware classes!</h1></body></html>");
            });
        }
    }
}