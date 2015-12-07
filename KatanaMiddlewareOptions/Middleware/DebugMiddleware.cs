using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace KatanaMiddlewareOptions.Middleware
{
    public class DebugMiddleware
    {
        AppFunc _next;
        DebugMiddlewareOptions _options;

        // How do we get the options class inside our middleware? secondary optional parameter
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            // here we're just checking if our actions are null, and if they are assign them some default behavior:
            if (_options.OnIncomingRequest == null)
                _options.OnIncomingRequest = (ctx) => Debug.WriteLine("Incoming request: " + ctx.Request.Path);

            if (_options.OnOutGoingRequest == null)
                _options.OnOutGoingRequest = (ctx) => Debug.WriteLine("Outgoing request: " + ctx.Request.Path);
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            // now inside our middleware, we just invoke the delegates passed to us externally!
            // Nice Open & Closed principle :)

            _options.OnIncomingRequest(ctx);

            await _next(environment);

            _options.OnOutGoingRequest(ctx);
        }
    }
}