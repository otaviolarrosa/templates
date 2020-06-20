using FluentNHibernate.Mapping;
using TemplateMicroservice.Domain.Entities;

namespace TemplateMicroservice.Infrastructure.Data.EntitiesMapping
{
    public class TenantMapping : ClassMap<Tenant>
    {
        public TenantMapping()
        {
            Id(_ => _.Id);
            Map(_ => _.Name);
        }
    }
}