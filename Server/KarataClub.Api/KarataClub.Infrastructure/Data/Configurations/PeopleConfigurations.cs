using KarataClub.Domain.People;

namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class PeopleConfigurations : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Email).HasMaxLength(50);
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(15);
        builder.Property(p => p.Address).IsRequired().HasMaxLength(255);
        builder.HasOne(p => p.Member).WithOne(m => m.Person);
        builder.HasOne(p => p.Instructor).WithOne(i => i.Person);
    }
}
