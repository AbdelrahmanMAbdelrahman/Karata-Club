


namespace KarataClub.Infrastructure.Data.Configurations
{
    public sealed class BeltRankFileConfiguration : IEntityTypeConfiguration<BeltRankFile>
    {
        public void Configure(EntityTypeBuilder<BeltRankFile> builder)
        {
            builder.ToTable("BeltRankFiles");
            builder.HasOne(b=>b.UploadedFile).WithOne(u=>u.BeltRankFile);
            builder.HasOne(b => b.BeltRank).WithOne(b=>b.BeltRankFile);

        }
    }
}
