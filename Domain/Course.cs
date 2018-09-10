using System.Collections.Generic;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Class> Classes { get; set; }

        public Course()
        {
            Classes = new List<Class>();
        }
    }
}