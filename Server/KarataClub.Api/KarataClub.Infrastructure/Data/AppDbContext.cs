namespace KarataClub.Infrastructure.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options,IMediator mediator) : DbContext(options), IAppDbContext
    {
        public DbSet<BeltTest> BeltTests => Set<BeltTest>();

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
