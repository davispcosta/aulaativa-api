using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            ToTable("Questions");
            HasKey(x => x.Id);
        }
    }
}
