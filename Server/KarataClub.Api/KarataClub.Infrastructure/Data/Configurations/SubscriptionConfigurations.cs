

using KarataClub.Domain.Courses.Subscriptions;

namespace KarataClub.Infrastructure.Data.Configurations
{
    internal class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");
            builder.Property(s => s.StartDate).IsRequired();
            builder.Property(s => s.EndDate).IsRequired();
            builder.Property(s => s.Fees).IsRequired();
            builder.HasOne(s => s.Payment).WithOne(p=>p.Subscription);
            builder.HasOne(s => s.Member).WithMany(m => m.Subscriptions);

        }
    }
}
