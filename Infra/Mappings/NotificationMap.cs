using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            ToTable("Notifications");
            HasKey(x => x.Id);
        }
    }
}
