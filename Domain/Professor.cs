using System.Collections.Generic;

namespace Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
        public virtual ICollection<Doubt> Doubts { get; set; }
        public virtual ICollection<DoubtAnswer> Answers { get; set; }

        public Professor()
        {
            Classes = new List<Class>();
            Doubts = new List<Doubt>();
            Answers = new List<DoubtAnswer>();
        }
    }
}