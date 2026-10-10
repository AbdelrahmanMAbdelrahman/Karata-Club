namespace KarataClub.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<BeltTest> BeltTests { get; }
        public Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
