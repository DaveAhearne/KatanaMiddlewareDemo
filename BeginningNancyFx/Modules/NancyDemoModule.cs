using Nancy;
using Nancy.Owin;

namespace BeginningNancyFx.Modules
{
    // Our new nancy modules MUST inherit from nancyModule
    public class NancyDemoModule : NancyModule
    {
        // Inside the Nancy base class, theres a dictionary for each of the HTTP verbs.

        public NancyDemoModule()
        {
            // So here we're using the GET dictionary, and the path we want to handle as the key
            // And then the delegate for the value.

            // And matching request will then execute the delegate: 
            Get["/nancy"] = x =>
            {
                // What if we want to do things with the request context?
                // We can get the OwinContext we've seen before via the extention method of the Context property in the NancyModule base class

                // Remember, we could just create an OwinContext from this:
                var env = Context.GetOwinEnvironment();

                return "Running from NancyFx - Your path was: " + env["owin.RequestPath"];
            };
        }
    }
}