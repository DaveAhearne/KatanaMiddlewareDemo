using System.Linq;
using Nancy;
using Nancy.Responses;
using NancyOwinRoutingDemo.Models;

namespace NancyOwinRoutingDemo.Modules
{
    public class CoursesModule : NancyModule
    {
        public CoursesModule()
        {
            // Note we put our courses in a seperate module, but we werent forced too,
            // Also note that Nancy provides a serializer for us
            Get["/courses"] = o => new JsonResponse(Course.List, new DefaultJsonSerializer());

            // Here we have our optional parameter, notice on the right how Nancy provides the template values we use as a dynamic dictionary
            Get["/courses/{id}"] = o => Response.AsJson(Course.List.First(x => x.Id == o.id));

            Post["/courses"] = o =>
            {
                // url encoded forms go inside the dynamic request form dictionary:
                var name = this.Request.Form.Name;
                var author = this.Request.Form.Author;

                var id = Course.AddCourse(name, author);

                // Creates our location header back to the object we created
                string url = string.Format("{0}/{1}", this.Context.Request.Url, id);

                return new Response()
                {
                    StatusCode = HttpStatusCode.Accepted
                }
                    .WithHeader("location", url);
            };
        }
    }
}