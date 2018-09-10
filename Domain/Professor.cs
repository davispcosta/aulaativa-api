using System.Collections.Generic;

namespace Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Class> Classes { get; set; }

        public Professor()
        {
            Classes = new List<Class>();
        }
    }
}