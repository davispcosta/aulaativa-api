using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Students");
            HasKey(x => x.Id);
        }
    }
}
