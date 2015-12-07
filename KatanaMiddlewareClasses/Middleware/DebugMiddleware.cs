// This using isn't essential, but its easier than rewriting it all:

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace KatanaMiddlewareClasses.Middleware
{
    // A lot of examples will inherit from the base class "owinmiddleware"
    // this is from katana, but its katana specific, so it limits reusability.

    public class DebugMiddleware
    {
        AppFunc _next;

        // The next here is the same as the next that we had in the delegate based middleware (Reference to next in pipeline).
        public DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        // So how do we invoke this middleware? Write an invoke method that takes an IDictionary string-object that returns a task:
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Also previously we had an IOwinContext as a parameter, but now we have the enviroment dictionary, to convert it
            // Just instantiate an OwinContext and pass it as a parameter:
            var ctx = new OwinContext(environment);

            // Remember we could just as well do the following instead:
            //var path = (string)environment["owin.RequestPath"];

            Debug.WriteLine("Incoming request: " + ctx.Request.Path);

            await _next(environment); // Because the next is now an AppFunc, it expects the enviroment dictionary we take as a parameter
            // This makes sense because we're passing the modified dictionary through the middlewares

            Debug.WriteLine("Outgoing request: " + ctx.Request.Path);
        }
    }
}