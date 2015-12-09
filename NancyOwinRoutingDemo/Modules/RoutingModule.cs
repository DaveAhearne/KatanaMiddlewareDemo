using Microsoft.Owin;
using Nancy;
using Nancy.Owin;

namespace NancyOwinRoutingDemo.Modules
{
    public class RoutingModule : NancyModule
    {
        public RoutingModule()
        {
            Get["/orders", c => c.Request.Query["page"] == "true"] = o =>
            {
                var that = this.Context.Request;
                return "Your v. complicated order with queries";
            };

            // At the moment, if you try to do the top one via "/orders?page=true" you'll always get the literal
            // because the predicate is not evaluated for scoring, only the path
            Get["/orders"] = o => { return "Your simple order"; };

            Get["/orders/{id}"] = o => { return "Your complicated order with parameters"; };


            // Defining custom Routes for user agents:
            // We can give our routes conditions via predicates, our method dictionaries take a second optional parameter of
            // a Func that returns a bool, and provides us the nancyContext
            Get["/", ctx => isIE11(ctx.Request)] = o => { return "You're here from IE!"; };
        }

        private bool isIE11(Request request)
        {
            return request.Headers.UserAgent.Contains("Trident/7.0");
        }
    }
}