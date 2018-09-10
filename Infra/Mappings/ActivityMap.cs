using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class ActivityMap : EntityTypeConfiguration<Activity>
    {
        public ActivityMap()
        {
            ToTable("Activities");
            HasKey(x => x.Id);
        }
    }
}
