using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class HistoricAnswerQuizMap : EntityTypeConfiguration<HistoricAnswerQuiz>
    {
        public HistoricAnswerQuizMap()
        {
            ToTable("HistoricsAnswerQuiz");
            HasKey(x => x.Id);
        }
    }
}
