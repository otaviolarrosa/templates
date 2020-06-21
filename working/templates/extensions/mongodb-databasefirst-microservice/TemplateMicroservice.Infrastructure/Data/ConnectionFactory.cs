using MongoDB.Driver;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data;
using TemplateMicroservice.Infrastructure.Utils.ExtensionMethods;
using TemplateMicroservice.Infrastructure.Utils.Settings;

namespace TemplateMicroservice.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IMongoDatabase database;

        private string collectionName;

        private string connectionString = AppSettings.GetAppSetting("DatabaseConnectionString");

        private string databaseName = AppSettings.GetAppSetting("DatabaseName");

        public IMongoDatabase GetDatabase()
        {
            database = new MongoClient(connectionString).GetDatabase(databaseName);
            return database;
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : Entity
        {
            if (database.IsNull())
            {
                database = new MongoClient(connectionString).GetDatabase(databaseName);
            }

            return database.GetCollection<TDocument>(this.collectionName);
        }

        public string GetCollectionName() => collectionName;

        public void SetCollectionName(string value) => collectionName = value;
    }
}