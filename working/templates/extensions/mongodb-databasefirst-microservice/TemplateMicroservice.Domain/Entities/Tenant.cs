using System.Diagnostics.CodeAnalysis;

namespace TemplateMicroservice.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Tenant : Entity
    {
        public string Name { get; set; }
    }
}