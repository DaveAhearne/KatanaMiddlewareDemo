using System;
using Microsoft.Owin;

namespace KatanaMiddlewareUseMethod.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }

        public Action<IOwinContext> OnOutGoingRequest { get; set; }
    }
}