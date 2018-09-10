using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class ClassMap : EntityTypeConfiguration<Class>
    {
        public ClassMap()
        {
            ToTable("Alternatives");
            HasKey(x => x.Id);
        }
    }
}
