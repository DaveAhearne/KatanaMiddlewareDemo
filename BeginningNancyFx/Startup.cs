using BeginningNancyFx.Middleware;
using Nancy;
using Nancy.Owin;
using Owin;

namespace BeginningNancyFx
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // To get started with nancy install nancy.owin (Because we're using nancy via owin)

            // You define nancy "Modules" and those modules decide what paths to repond to.

            app.UseDebugMiddleware();

            // Note that because Nancy follows the pattern we outlined before, we only have to do this and we're done:
            // Any NancyModules we declared are automatically found:
            app.UseNancy();
            
            app.UseDebugMiddleware(new DebugMiddlewareOptions()
            {
                OnIncomingRequest = context => context.Response.WriteAsync("## The beginning ##"),
                OnOutGoingRequest = context => context.Response.WriteAsync("## The end ##")
            });

            /*
             * Problem: - Why do we get a 404 now? Why doesnt our pipeline continue past Nancy if the request doesnt match?
             * Answer: - Nancy is short circuiting and returning a response for us.
             */

            
            // One solution is to use the Map method, this sets a middleware for a specific path
            // In this case we map /nancy to an IAppBuilder and then tell that specific path only to use Nancy
            //app.Map("/nancy", mappedApplication => mappedApplication.UseNancy());

            
            /*
             * There is a problem with this though, if you attempt to go to that path now, it will 404, and you will need to go to /nancy/nancy to see
             * on top of that, the enviroment path we are writing out will only display /nancy? (need to display the request path base aswell to show the full url)
             * 
             * This is due to the fact that Nancy performs its Routing based on the request path, rather than including the request path base.             * 
             * 
             */

            // A better way is to use NancyConfigurations to say, if the response code is any of the ones we say e.g 404 pass through the pipeline
            // nancy is a bit different in that it uses a delegate as an options class but it works the same:
            app.UseNancy(options => options.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound));
        }
    }
}