using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class DoubtAnswerMap : EntityTypeConfiguration<DoubtAnswer>
    {
        public DoubtAnswerMap()
        {
            ToTable("DoubtAnswers");
            HasKey(x => x.Id);
        }
    }
}
