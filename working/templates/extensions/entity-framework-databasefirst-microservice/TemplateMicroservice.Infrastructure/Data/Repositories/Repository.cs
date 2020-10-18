using Microsoft.EntityFrameworkCore;
using System.Linq;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories;
using TemplateMicroservice.Infrastructure.Data.DatabaseContext;

namespace TemplateMicroservice.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _databaseContext;
        private DbSet<TEntity> entities;

        public Repository(DataContext context)
        {
            _databaseContext = context;
            entities = context.Set<TEntity>();
        }

        public void Delete(long id)
        {
            TEntity entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            _databaseContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll() => entities.AsQueryable();

        public TEntity GetById(long id) => entities.SingleOrDefault(x => x.Id == id);

        public void Insert(TEntity entity)
        {
            entities.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Update(TEntity entity) => _databaseContext.SaveChanges();
    }
}
