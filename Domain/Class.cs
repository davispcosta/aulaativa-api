using System.Collections.Generic;

namespace Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxAbsence { get; set; }

        public virtual Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Doubt> Doubts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Class()
        {
            Subscriptions = new List<Subscription>();
            Courses = new List<Course>();
            Achievements = new List<Achievement>();
            Activities = new List<Activity>();
            Quizzes = new List<Quiz>();
            Doubts = new List<Doubt>();
        }

    }
}