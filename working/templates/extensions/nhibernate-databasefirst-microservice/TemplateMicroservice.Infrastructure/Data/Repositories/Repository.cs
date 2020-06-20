using System.Collections.Generic;
using System.Linq;
using NHibernate;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.UnityOfWork;
using TemplateMicroservice.Infrastructure.Data.UnitOfWork;
using TemplateMicroservice.Infrastructure.Utils.ExtensionMethods;

namespace TemplateMicroservice.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ISession Session { get { return unitOfWork.Session; } }

        private readonly UnitOfWorkImpl unitOfWork;

        public Repository(IUnitOfWork unitOfWork) => this.unitOfWork = (UnitOfWorkImpl)unitOfWork;

        public IQueryable<TEntity> GetAll() => Session.Query<TEntity>();

        public TEntity GetById(long id) => Session.Get<TEntity>(id);

        public long Insert(TEntity entity) => Session.Save(entity).ToLong();

        public void Update(TEntity entity) => Session.Update(entity);

        public void Delete(long id) => Session.Delete(Session.Load<TEntity>(id));
    }
}