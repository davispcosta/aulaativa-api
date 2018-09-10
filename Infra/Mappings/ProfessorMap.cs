using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class ProfessorMap : EntityTypeConfiguration<Professor>
    {
        public ProfessorMap()
        {
            ToTable("Professors");
            HasKey(x => x.Id);
        }
    }
}
