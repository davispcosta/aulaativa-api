using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class DoubtMap : EntityTypeConfiguration<Doubt>
    {
        public DoubtMap()
        {
            ToTable("Doubts");
            HasKey(x => x.Id);
        }
    }
}
