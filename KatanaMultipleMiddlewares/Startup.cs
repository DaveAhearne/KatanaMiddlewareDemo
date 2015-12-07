using System.Diagnostics;
using Owin;

namespace KatanaMultipleMiddlewares
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // When having multiple middlewares, the ordering is essential, higher middlewares are executed first in the pipeline:

            app.Use(async (ctx, next) =>
            {
                Debug.WriteLine("Incoming request: " + ctx.Request.Path);

                /*
                 * When you have more than one middleware in your pipeline, you have to execute the next middleware in the pipeline
                 * via the delegate thats passed in, if this wasn't done the pipeline would die at the first request.
                 */

                await next(); // This signals the end of the forward pass through

                /*
                 * At this point we've already sent the response headers, and the response body is now coming back
                 * we can no longer change the response headers, but we can still append to the response body or execute arbitrary code
                 * (This behavior can be changed, but its not easy to do.)
                 */

                Debug.WriteLine("Outgoing request: " + ctx.Request.Path);
            });

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Now we're in pipelines!");
            });
        }
    }
}