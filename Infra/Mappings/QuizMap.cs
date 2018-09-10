using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            ToTable("Quizzes");
            HasKey(x => x.Id);
        }
    }
}
