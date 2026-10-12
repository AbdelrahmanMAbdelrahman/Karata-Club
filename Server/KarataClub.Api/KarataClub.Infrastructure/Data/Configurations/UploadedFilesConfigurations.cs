using KarataClub.Domain.UploadedFiles;

namespace KarataClub.Infrastructure.Data.Configurations;

public sealed class UploadedFilesConfigurations : IEntityTypeConfiguration<UploadedFile>
{
    public void Configure(EntityTypeBuilder<UploadedFile> builder)
    {
        builder.ToTable("UploadedFiles");
        builder.Property(uf=>uf.FileName).IsRequired();
        builder.Property(uf=>uf.Extension).IsRequired();
        builder.Property(uf=>uf.StoredFileName).IsRequired();
        builder.Property(uf=>uf.Size).IsRequired();
        builder.HasOne(uf => uf.CourseFile).WithOne(cf => cf.UploadedFile);
        builder.HasOne(ur => ur.BeltRankFile).WithOne(brf=>brf.UploadedFile);
    }
}
