
using TodoistClone.Domain.Primitives;

namespace TodoistClone.Application.Common.Interfaces.Persistence
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
