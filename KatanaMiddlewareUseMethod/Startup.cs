using System.Diagnostics;
using KatanaMiddlewareUseMethod.Middleware;
using Owin;

namespace KatanaMiddlewareUseMethod
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            /*
             * Typically, when we add middleware we DONT use the generic Use method, instead we use a named method like:
             * app.useX();
             * 
             * These are just extentions to IAppBuilder
             */

            // So now we can just do:
            app.UseDebugMiddleware();

            // And:
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
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
                }
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Now we've moved into middleware classes!</h1></body></html>");
            });
        }
    }
}