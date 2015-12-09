using Owin;

namespace NancyOwinRoutingDemo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}