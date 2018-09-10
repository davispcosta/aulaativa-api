using System.Collections.Generic;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<HistoricAnswerQuiz> Historics { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Doubt> Doubts { get; set; }
        public virtual ICollection<DoubtAnswer> Answers { get; set; }

        public Student()
        {
            Subscriptions = new List<Subscription>();
            Historics = new List<HistoricAnswerQuiz>();
            Achievements = new List<Achievement>();
            Doubts = new List<Doubt>();
            Answers = new List<DoubtAnswer>();
        }
    }
}