using System.Collections.Generic;

namespace Domain
{
    public class Achievement
    {
        public int Id { get; set; }

        public virtual Class Class { get; set; }
        public int ClassId { get; set; }

        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Achievement()
        {
            Students = new List<Student>();
        }
    }
}