using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class ClassMap : EntityTypeConfiguration<Class>
    {
        public ClassMap()
        {
            ToTable("Classes");
            HasKey(x => x.Id);
        }
    }
}
