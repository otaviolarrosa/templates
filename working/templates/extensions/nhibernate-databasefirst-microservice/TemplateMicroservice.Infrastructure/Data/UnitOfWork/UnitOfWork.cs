using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.UnityOfWork;
using TemplateMicroservice.Infrastructure.Data.EntitiesMapping;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private static string CONNECTION_STRING;
        private static readonly ISessionFactory sessionFactory;
        public ISession Session { get; private set; }
        private ITransaction transaction;

        static UnitOfWorkImpl()
        {
            CONNECTION_STRING = AppSettings.GetAppSetting("DatabaseConnectionString");
            sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString => connectionString.Is(CONNECTION_STRING)))
                .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<TenantMapping>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(useStdOut: false, doUpdate: true))
                .BuildSessionFactory();
        }

        public UnitOfWorkImpl()
        {
            Session = sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Commit();
            }
            catch
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void RollBack()
        {
            try
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}