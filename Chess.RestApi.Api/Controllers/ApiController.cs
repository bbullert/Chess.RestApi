using Chess.RestApi.Api.Models;
using Chess.RestApi.Core.Exceptions;
using Chess.RestApi.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Chess.RestApi.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {

        protected const string StandardInternalServerError = "An unexpected error has occurred";

        protected virtual OkObjectResult Ok<T>(T obj)
        {
            var response = new ApiResponse<object>()
            {
                Result = obj
            };

            return base.Ok(response);
        }

        protected virtual BadRequestObjectResult BadRequest(ValidationResult result)
        {
            var response = new ApiResponse<ValidationResult>()
            {
                Result = result,
                Status = (int)HttpStatusCode.BadRequest,
                Details = "Validation failed"
            };

            return base.BadRequest(response);
        }

        protected virtual BadRequestObjectResult BadRequest(ApiException ex)
        {
            var response = new ApiResponse<object>()
            {
                Status = (int)HttpStatusCode.BadRequest,
                Details = ex.Message
            };

            return base.BadRequest(response);
        }

        protected new virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        {
            var result = new ValidationResult();
            foreach (var key in modelState.Keys)
            {
                result.AddError(new ValidationError()
                {
                    Name = key,
                    Messages = modelState[key].Errors.Select(e => e.ErrorMessage)
                });
            }

            return BadRequest(result);
        }

        protected virtual ObjectResult InternalServerError(Exception ex, string error = StandardInternalServerError)
        {
            var response = new ApiResponse<object>()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Details = error
            };

            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }
}
