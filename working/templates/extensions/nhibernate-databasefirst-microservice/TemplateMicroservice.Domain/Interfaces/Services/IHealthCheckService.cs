using TemplateMicroservice.Domain.ViewModels.HealthCheck;

namespace TemplateMicroservice.Domain.Interfaces.Services
{
    public interface IHealthCheckService
    {
         HealthCheckViewModel VerifyHealthCheck();
    }
}