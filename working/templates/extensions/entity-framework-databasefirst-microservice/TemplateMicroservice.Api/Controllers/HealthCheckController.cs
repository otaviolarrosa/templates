using System;
using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Domain.Interfaces.Services;
using TemplateMicroservice.Domain.ViewModels;

namespace TemplateMicroservice.Api.Controllers
{
    public class HealthCheckController : BaseApiController
    {
        private readonly IHealthCheckService healthCheckService;
        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            this.healthCheckService = healthCheckService;
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            try
            {
                var result = healthCheckService.VerifyHealthCheck();
                return Sucess(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}