using KarataClub.Domain.People.Members.Attendencies;
using KarataClub.Domain.People.Members.MemberAttendencies;

namespace KarataClub.Infrastructure.Data.Configurations;

public class MemberAttendenceConfiguration : IEntityTypeConfiguration<MemberAttendence>
{
    public void Configure(EntityTypeBuilder<MemberAttendence> builder)
    {
        builder.ToTable("MemberAttendencies");
        builder.HasOne(a => a.Session).WithMany(a => a.MemberAttendencies);
        builder.HasOne(a => a.Member).WithMany(m => m.MemberAttendencies);
    }
}
