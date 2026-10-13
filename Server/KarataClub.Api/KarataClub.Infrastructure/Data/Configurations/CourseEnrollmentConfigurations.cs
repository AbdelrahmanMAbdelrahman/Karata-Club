using KarataClub.Domain.Courses.Enrollments;

namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class CourseEnrollmentConfigurations : IEntityTypeConfiguration<CourseEnrollment>
{
    public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
    {
        builder.ToTable("CourseEnrollments");
        builder.HasOne(ce => ce.Payment).WithOne(p=>p.CourseEnrollment);
        builder.HasOne(ce => ce.Member).WithMany(m => m.CourseEnrollments);
        builder.HasOne(ce => ce.Course).WithMany(c=>c.CourseEnrollments);
        
    }
}
