using System.Diagnostics.CodeAnalysis;

namespace TemplateMicroservice.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public long Id { get; set; }
    }
}