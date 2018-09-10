using System.Collections.Generic;

namespace Domain
{
    public class Doubt
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Question { get; set; }

        public virtual ICollection<DoubtAnswer> Answers { get; set; }

        public Doubt()
        {
            Answers = new List<DoubtAnswer>();
        }
    }
}