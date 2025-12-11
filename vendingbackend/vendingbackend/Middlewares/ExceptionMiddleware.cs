using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace vendingbackend.Middlewares
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> _logger)
        {
            _next = next;
            this._logger = _logger;
        }

        public RequestDelegate _next { get; }
        public ILogger<ExceptionMiddleware> _logger { get; }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"Необработанная ошибка: {Message}",ex.Message);
                var statusCode = StatusCodes.Status500InternalServerError;
                var message = "Внутренняя ошибка сервера.";

                switch (ex)
                {

                    case ArgumentException _:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = "Ошибка валидации.";
                        break;

                    case KeyNotFoundException _:
                        statusCode = StatusCodes.Status404NotFound;
                        message = "Ресурс не найден.";
                        break;

                    case DbUpdateException _:
                        statusCode = StatusCodes.Status409Conflict;
                        message = "Ошибка в базе данных";
                        break;

                    case NullReferenceException _:
                        statusCode = StatusCodes.Status404NotFound;
                        message = ex.Message;
                        break;

                    default:
                        message = $"Необработанное исключение: {ex.GetType}\nТекст ошибки: {ex.Message}";
                        break;

                }
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(message);
            }
        }
    }
}
