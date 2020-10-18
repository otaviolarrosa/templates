using System.ComponentModel;

namespace TemplateMicroservice.Domain.Enums.HealthCheckStatus
{
    public enum HealthCheckStatusEnum
    {
        [Description("Up")]
        Up = 1,
        [Description("Down")]
        Down = 2
    }
}