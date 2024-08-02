using MongoDB.Bson.Serialization.Attributes;
namespace TodoistClone.Domain.Primitives
{
    public abstract class Entity
    {

        [BsonRequired]
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid _Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Entity()
        {
            _Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity(Guid id)
        {
            _Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
