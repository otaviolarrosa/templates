using System.Diagnostics.CodeAnalysis;

namespace TemplateMicroservice.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}