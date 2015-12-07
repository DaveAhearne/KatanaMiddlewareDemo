
using System;
using Microsoft.Owin;

namespace KatanaMiddlewareOptions.Middleware
{
    // The options class is a plain class, with properties that correspond to the things we want to configure
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }

        public Action<IOwinContext> OnOutGoingRequest { get; set; } 
    }
}