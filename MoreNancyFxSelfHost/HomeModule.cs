using Nancy;

namespace MoreNancyFxSelfHost
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            // Note that when returning a view file, you need to copy to output, or you'll get a 500:
            Get["/"] = o => View["index.html"];
        }
    }
}