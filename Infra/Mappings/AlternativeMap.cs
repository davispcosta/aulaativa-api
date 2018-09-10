using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class AlternativeMap : EntityTypeConfiguration<Alternative>
    {
        public AlternativeMap()
        {
            ToTable("Alternatives");
            HasKey(x => x.Id);
        }
    }
}
