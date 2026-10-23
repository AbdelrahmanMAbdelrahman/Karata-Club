namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class BeltTestConfigurations : IEntityTypeConfiguration<BeltTest>
{
    public void Configure(EntityTypeBuilder<BeltTest> builder)
    {
        builder.ToTable("BeltTests");
        builder.Property(bt => bt.TestDate).IsRequired();
        builder.Property(bt => bt.ReservationDate).IsRequired();
        //builder.Property(bt=>bt.PaymentStatus).IsRequired().HasDefaultValue(PaymentStatus.UnPaid);
        builder.HasOne(bt => bt.Payment).WithOne(p=>p.BeltTest);
        builder.HasOne(bt => bt.Instructor).WithMany(i=>i.BeltTests);
        builder.HasOne(bt => bt.Member).WithMany(m=>m.BeltTests);
        builder.HasOne(bt => bt.BeltRank).WithMany(br => br.BeltTests);
    }
}
