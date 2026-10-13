using KarataClub.Domain.Courses.Sessions;

namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class SessionConfigurations : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");
        builder.Property(s=>s.SessionDate).IsRequired();
        builder.Property(s=>s.NumberOfHours).IsRequired();
        builder.HasOne(s => s.Course).WithMany(c => c.Session);
        builder.HasMany(s => s.Attendances).WithOne(a => a.Session);

    }
}
