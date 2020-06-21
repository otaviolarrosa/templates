using System;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Enums.HealthCheckStatus;
using TemplateMicroservice.Domain.Interfaces.Infrastructure.Data.Repositories;
using TemplateMicroservice.Domain.Interfaces.Services;
using TemplateMicroservice.Domain.ViewModels.HealthCheck;
using TemplateMicroservice.Infrastructure.Utils.ExtensionMethods;

namespace TemplateMicroservice.Domain.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IBaseRepository<Tenant> tenantRepository;

        public HealthCheckService(IBaseRepository<Tenant> tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        public HealthCheckViewModel VerifyHealthCheck()
        {
            var result = new HealthCheckViewModel();
            result.DatabaseStatus = VerifyDatabaseStatus();
            return result;
        }

        private string VerifyDatabaseStatus()
        {
            try
            {
                tenantRepository.GetById("1");
                return HealthCheckStatusEnum.Up.GetDescription();
            }
            catch (Exception)
            {
                return HealthCheckStatusEnum.Down.GetDescription();
            }
        }
    }
}