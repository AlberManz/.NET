using System.Net;

namespace _66.WebApi_Cars.Middlewares
{
	public class ExceptionHandlingMiddleware
	{
		public readonly RequestDelegate _requestDelegate;

		private readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_requestDelegate = requestDelegate;
			_logger = logger;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _requestDelegate(context);
			}
			catch (Exception ex)
			{
				await HandleException(context, ex);
			}
		}

		private Task HandleException(HttpContext context, Exception ex)
		{
			_logger.LogError(ex.ToString());
			
			var errorMessageObject = new { Message = ex.Message, Code = "system_error" };
			var errorMessage = System.Text.Json.JsonSerializer.Serialize(errorMessageObject);
			
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			
			return context.Response.WriteAsync(errorMessage);
		}
	}
}


