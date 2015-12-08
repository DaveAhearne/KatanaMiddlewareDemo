using BeginningNancyFx.Middleware;

// Putting it in the Owin namespace makes it easy to find
namespace Owin
{
    public static class DebugMiddlewareExtensions
    {
        // So here we're extending the IAppBuilder to have our method, and we need the options class too (But it should be optional):
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();

            // So now we've moved what was in our startup class into here:
            app.Use<DebugMiddleware>(options);
        }
    }
}