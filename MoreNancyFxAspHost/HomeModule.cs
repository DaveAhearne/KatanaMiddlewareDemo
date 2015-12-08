using Nancy;

namespace MoreNancyFxAspHost
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = o => "Hello World - AspHosted";
        }
    }
}