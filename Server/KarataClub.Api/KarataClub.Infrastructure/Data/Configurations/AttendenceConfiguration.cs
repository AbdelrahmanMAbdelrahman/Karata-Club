using KarataClub.Domain.Attendencies;

namespace KarataClub.Infrastructure.Data.Configurations;

public class AttendenceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendencies");
        builder.HasOne(a => a.Session).WithMany(a => a.Attendances);
        builder.HasOne(a => a.Member).WithMany(m => m.Attendances);
    }
}
