using System.Collections.Generic;
using System.Linq;

namespace NancyOwinRoutingDemo.Models
{
    public class Course
    {
        // Simple model for us to use:

        public Course(int id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public static IList<Course> List = new List<Course>()
        {
            new Course(0, "French 101", "French man"),
            new Course(1, "Learning the guitar", "Slimm Jimms")
        };

        public static int AddCourse(string name, string author)
        {
            var id = Course.List.Any() ? Course.List.Max(x => x.Id) + 1 : 0;

            Course.List.Add(new Course(id, name, author));

            return id;
        }
    }
}