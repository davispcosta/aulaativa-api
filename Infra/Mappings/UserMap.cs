using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(x => x.Id);
        }
    }
}
