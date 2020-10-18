using TemplateMicroservice.Domain.Enums.HealthCheckStatus;

namespace TemplateMicroservice.Domain.ViewModels.HealthCheck
{
    public class HealthCheckViewModel : BaseViewModel
    {
        public string DatabaseStatus { get; set; }
    }
}