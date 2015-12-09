using Owin;

namespace KatanaOwinSimple
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            /*
             * Why OWIN? It allows you to abstract the server away so we're not bothered about how our application is hosted
             * 
             * How do you abstract any server, current and future, without limiting them whilst keeping it simple?
             * Its a simple delegate, a Func<IDictionary<string,object>, Task>;
             * 
             */

            app.Use(async (ctx, next) =>
            {
                // Katana API implementation
                //await ctx.Response.WriteAsync("Hello World");

                // Raw implementation
                //var responseStream = (Stream)ctx.Environment["owin.ResponseBody"];
                //const string outputString = "Hello World";
                //await responseStream.WriteAsync(Encoding.UTF8.GetBytes(outputString), 0, outputString.Length);

                // If you want HTML output, you have to write it yourself for the moment:
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Simple Example</h1></body></html>");
            });
        }
    }
}