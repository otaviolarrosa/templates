using System.Diagnostics.CodeAnalysis;

namespace TemplateMicroservice.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Tenant : Entity
    {
        public virtual string Name { get; set; }
    }
}