using System.Linq;
using TemplateMicroservice.Domain.Entities;

namespace TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(long id);
        long Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(long id);
    }
}