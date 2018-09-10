using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public int? StudentId { get; set; }
        public virtual Professor Professor { get; set; }
        public int? ProfessorId { get; set; }

        public virtual ICollection<Doubt> Doubts { get; set; }
        public virtual ICollection<DoubtAnswer> Answers { get; set; }

        public User()
        {
            Doubts = new List<Doubt>();
            Answers = new List<DoubtAnswer>();
        }

    }
}