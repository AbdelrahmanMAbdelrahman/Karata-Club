namespace KarataClub.Domain.Common
{
    public abstract class AuditEntity:Entity
    {
        protected AuditEntity()
        {
            
        }
        protected AuditEntity(Guid id):base(id)
        {
            
        }
        public Guid CreatedBy { get;private set; }
        public Guid LastModifiedBy { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime LastModifiedAt { get;private set; }
    }
}
