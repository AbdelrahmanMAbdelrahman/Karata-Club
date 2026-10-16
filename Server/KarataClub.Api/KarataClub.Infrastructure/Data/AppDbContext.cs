




using KarataClub.Domain.Subscriptions;

namespace KarataClub.Infrastructure.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options,IMediator mediator)// appdbcontext cs0311
        : IdentityDbContext<AppUser,IdentityRole,string>(options), IAppDbContext
    {
        public DbSet<BeltTest> BeltTests => Set<BeltTest>();

        public DbSet<Attendance> Attendancies => Set<Attendance>();

        public DbSet<BeltRank> BeltRanks => Set<BeltRank>();

        public DbSet<BeltRankFile> BeltRankFiles => Set<BeltRankFile>();

        public DbSet<CourseFile> CourseFiles => Set<CourseFile>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<CourseEnrollment> Enrollments => Set<CourseEnrollment>();

        public DbSet<Payment> Payments => Set<Payment>();

        public DbSet<Person> People => Set<Person>();

        public DbSet<Member> Members => Set<Member>();

        public DbSet<Instructor> Instructors => Set<Instructor>();

        public DbSet<Session> Sessions => Set<Session>();

        public DbSet<Subscription> Subscription => Set<Subscription>();

        public DbSet<UploadedFile> UploadedFiles => Set<UploadedFile>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await DisboseDomainEvents(cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }

        private async Task DisboseDomainEvents(CancellationToken cancellationToken)
        {
           List<Entity> entities=ChangeTracker.Entries()
                .Where(e=>e.Entity is Entity baseEntity &&baseEntity.DomainEvents.Count()>0)
                .Select(e=>(Entity)e.Entity).ToList();
            List<DomainEvent> domainEvents=entities.SelectMany(e=>e.DomainEvents).ToList();

            foreach (DomainEvent domainEvent in domainEvents) {
            await mediator.Publish(domainEvent);
            }
            foreach (Entity entity in entities) {
                entity.ClearDomainEvents();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

   
}
