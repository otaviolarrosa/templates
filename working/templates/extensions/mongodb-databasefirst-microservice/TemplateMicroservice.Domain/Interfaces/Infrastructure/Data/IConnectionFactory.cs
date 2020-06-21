using MongoDB.Driver;
using TemplateMicroservice.Domain.Entities;

namespace TemplateMicroservice.Domain.Interfaces.Infrastructure.Data
{
    public interface IConnectionFactory
    {
        IMongoDatabase GetDatabase();
        IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : Entity;
        void SetCollectionName(string value);
        string GetCollectionName();
    }
}