
namespace KarataClub.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<BeltTest> BeltTests { get; }
        public DbSet<Attendance> Attendancies { get; }
        public DbSet<BeltRank> BeltRanks { get; }
        public DbSet<BeltRankFile> BeltRankFiles { get; }
        public DbSet<CourseFile> CourseFiles { get; }
        public DbSet<Course> Courses { get; }
        public DbSet<CourseEnrollment> Enrollments { get; }
        public DbSet<Payment> Payments { get; }
        public DbSet<Person> People { get; }
        public DbSet<Member> Members { get; }
        public DbSet<Instructor> Instructors { get; }
        public DbSet<Session> Sessions { get; }
        public DbSet<Subscription> Subscription { get; }
        public DbSet<UploadedFile> UploadedFiles { get; }
        public DbSet<RefreshToken> RefreshTokens { get; }


        public Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
