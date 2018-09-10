using Domain;
using Infra.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.DataContexts
{
    public class AulaAtivaDataContext : DbContext
    {
        public AulaAtivaDataContext() : base("AulaAtivaConnectionString")
        {
            Database.SetInitializer<AulaAtivaDataContext>(new AulaAtivaDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Doubt> Doubts { get; set; }
        public DbSet<HistoricAnswerQuiz> HistoricsAnswerQuiz { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<DoubtAnswer> DoubtAnswers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new SubscriptionMap());
            modelBuilder.Configurations.Add(new ProfessorMap());
            modelBuilder.Configurations.Add(new ClassMap());
            modelBuilder.Configurations.Add(new AlternativeMap());
            modelBuilder.Configurations.Add(new ActivityMap());
            modelBuilder.Configurations.Add(new AchievementMap());
            modelBuilder.Configurations.Add(new DoubtMap());
            modelBuilder.Configurations.Add(new HistoricAnswerQuizMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuizMap());
            modelBuilder.Configurations.Add(new DoubtAnswerMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class AulaAtivaDataContextInitializer : DropCreateDatabaseAlways<AulaAtivaDataContext>
    {
        protected override void Seed(AulaAtivaDataContext context)
        {
            context.Professors.Add(new Professor { Id = 1, Name = "Eduardo Melo" });
            context.Courses.Add(new Course { Id = 1, Name = "Sistemas de Informação" });

            context.SaveChanges();

            context.Classes.Add(new Class { Id = 1, ProfessorId = 1, Name = "Análise, Projeto e Implementação de Sistemas 1" });
            context.Classes.Add(new Class { Id = 1, ProfessorId = 1, Name = "Programação Orientada a Objetos" });
            context.Classes.Add(new Class { Id = 1, ProfessorId = 1, Name = "Computação Gráfica" });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
