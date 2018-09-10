using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Mappings
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            ToTable("Courses");
            HasKey(x => x.Id);
        }
    }
}
