using Activos.Application.Exceptions;
using Activos.Application.Models.Response;
using Activos.Infrastructure.Utils;
using Newtonsoft.Json;
using System.Net;

namespace Activos.ActivosAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                _logger.LogError(ex, ex.Message);
                var statusCode = (int)HttpStatusCode.InternalServerError;
                ApiResult<string?>? result = null;
                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = new ApiResult<string?>(statusCode, "VALIDATION_ERROR", validationJson);
                        //result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }

                if (result == null)
                    result = new ApiResult<string?>(statusCode, ex.Message, ex.StackTrace);


                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(ConvertToJson.Serialize(result));

            }

        }

    }
}
