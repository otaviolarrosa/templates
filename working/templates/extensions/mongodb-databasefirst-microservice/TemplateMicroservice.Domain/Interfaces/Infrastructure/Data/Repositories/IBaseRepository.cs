using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMicroservice.Domain.Entities;

namespace TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories
{
    public interface IBaseRepository<TDocument> where TDocument : Entity
    {
        List<TDocument> GetAll();
        Task<List<TDocument>> GetAllAsync();
        TDocument GetById(string id);
        Task<TDocument> GetByIdAsync(string id);
        string Create(TDocument document);
        Task<string> CreateAsync(TDocument document);
        void Replace(TDocument document);
        Task ReplaceAsync(TDocument document);
        void Delete(TDocument document);
        Task DeleteAsync(TDocument document);
    }
}