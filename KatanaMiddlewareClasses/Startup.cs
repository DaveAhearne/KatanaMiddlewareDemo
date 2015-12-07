using System.Diagnostics;
using KatanaMiddlewareClasses.Middleware;
using Owin;

namespace KatanaMiddlewareClasses
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // Now we're using the generic version of the app.use, and passing our middleware class to add it to the pipeline.
            app.Use<DebugMiddleware>();

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Now we've moved into middleware classes!</h1></body></html>");
            });
        }
    }
}