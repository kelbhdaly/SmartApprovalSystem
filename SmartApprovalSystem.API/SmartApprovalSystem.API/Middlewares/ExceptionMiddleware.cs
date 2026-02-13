using FluentValidation;
using SmartApprovalSystem.API.Exceptions;
using SmartApprovalSystem.API.Response;
using SmartApprovalSystem.Infrastructure.Exceptions;
using System.Net;

namespace SmartApprovalSystem.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            object response;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    response = new
                    {
                        success = false,
                        statusCode = (int)statusCode,
                        message = "Validation failed",
                        errors = validationException.Errors.Select(e => new
                        {
                            property = e.PropertyName,
                            error = e.ErrorMessage
                        })
                    };
                    break;

                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    response = new ErrorResponse(
                        exception.Message,
                        (int)statusCode);
                    break;
                case InvalidRegisterException:
                    statusCode = HttpStatusCode.BadRequest;
                    response = new ErrorResponse(
                        exception.Message,
                        (int)statusCode);
                    break;

                case UnauthorizedActionException:
                    statusCode = HttpStatusCode.Forbidden;
                    response = new ErrorResponse(
                        exception.Message,
                        (int)statusCode);
                    break;

                case EmailAlreadyExistsException:
                    statusCode = HttpStatusCode.Ambiguous;
                    response = new ErrorResponse(
                        exception.Message,
                        (int)statusCode);
                    break;
                case RoleNotFoundException:
                    statusCode = HttpStatusCode.Processing;
                    response = new ErrorResponse(
                        exception.Message,
                        (int)statusCode);
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    response = new ErrorResponse(
                        "An unexpected error occurred",
                        (int)statusCode);
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
