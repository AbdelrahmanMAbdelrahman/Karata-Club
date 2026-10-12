using KarataClub.Domain.Enrollments;
namespace KarataClub.Infrastructure.Data.Configurations;

internal class EnrollmentsConfigurations : IEntityTypeConfiguration<CourseEnrollment>
{
    public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
    {
        builder.ToTable("Enrollments");
        builder.HasOne(e => e.Member).WithMany(m => m.CourseEnrollments);
        builder.HasOne(e => e.Course).WithMany(c=>c.CourseEnrollments);
        builder.HasOne(e => e.Payment).WithOne(p => p.CourseEnrollment);
    }
}
