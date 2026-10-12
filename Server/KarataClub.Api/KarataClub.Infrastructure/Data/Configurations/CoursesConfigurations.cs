using KarataClub.Domain.Courses;
namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class CoursesConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.Property(c => c.NumberOfSessions).IsRequired();
        builder.Property(c=>c.CourseName).IsRequired();
        builder.Property(c=>c.TotalHours).IsRequired();
        builder.Property(c=>c.Fees).IsRequired();
        builder.Property(c=>c.Active).HasDefaultValue(true);
        builder.HasMany(c => c.CourseFiles).WithOne(cf => cf.Course);
        builder.HasMany(c => c.CourseEnrollments).WithOne(ce=>ce.Course);


    }
}
