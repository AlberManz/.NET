using Entities.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace _66.WebApi_Cars.Helpers
{
	public static class ValidationErrorsHelper
	{
		public static bool CheckValidationErrors(ValidationResult result, out IActionResult badRequest)
		{
			if (!result.IsValid)
			{
				var resposeError = new List<ErrorResponse>();

				foreach (var error in result.Errors)
				{
					resposeError.Add(new ErrorResponse
					{
						ErrorDescription = error.ErrorMessage
					});
				}

				{
					badRequest = new BadRequestObjectResult(resposeError);
					return true;
				}
			}

			badRequest = null;
			return false;
		}
	}
}
