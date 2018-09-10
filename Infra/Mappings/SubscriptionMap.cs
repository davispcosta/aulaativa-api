using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            ToTable("Subscriptions");
            HasKey(x => x.Id);
        }
    }
}
