using System.Collections.Generic;

namespace Domain
{
    public class Subscription
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Class Class { get; set; }
        public int ClassId { get; set; }
        public int Exp { get; set; }
        public int AbsenceCount { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }

        public Subscription()
        {
            Achievements = new List<Achievement>();
        }
    }
}