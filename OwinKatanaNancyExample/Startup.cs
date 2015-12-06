using Owin;

namespace KatanaOwinSimple
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                // Katana API implementation
                //await ctx.Response.WriteAsync("Hello World");

                // Raw implementation
                //var responseStream = (Stream)ctx.Environment["owin.ResponseBody"];
                //const string outputString = "Hello World";
                //await responseStream.WriteAsync(Encoding.UTF8.GetBytes(outputString), 0, outputString.Length);

                // If you want HTML output, you have to write it yourself for the moment:
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World</h1></body></html>");
            });
        }
    }
}