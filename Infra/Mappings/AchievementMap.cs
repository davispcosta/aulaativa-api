using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class AchievementMap : EntityTypeConfiguration<Achievement>
    {
        public AchievementMap()
        {
            ToTable("Achievements");
            HasKey(x => x.Id);
        }
    }
}
