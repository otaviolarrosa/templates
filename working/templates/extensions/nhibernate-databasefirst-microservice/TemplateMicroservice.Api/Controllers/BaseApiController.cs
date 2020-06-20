using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Domain.ViewModels;
using TemplateMicroservice.Infrastructure.Utils.ExtensionMethods;

namespace TemplateMicroservice.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult Sucess(BaseViewModel result)
        {
            if (result.Invalid)
            {
                var errors = new List<ErrorViewModel>();
                result.ValidationResult.Errors.ToList().ForEach(item =>
                {
                    errors.Add(new ErrorViewModel(item.PropertyName, item.ErrorMessage));
                });

                return BadRequest(errors);
            }
            return Ok(result);
        }

        protected IActionResult InternalServerError(Exception ex)
        {
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), ex);
        }
    }
}