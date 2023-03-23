using Entities.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace _65.API.Helpers
{
  public class ValidationErrorsHelper
  {
    public static bool CheckValidationResult(ValidationResult result, out IActionResult badRequest)
    {
      if (!result.IsValid)
      {
        var responseError = new List<ErrorResponse>();
        foreach (var error in result.Errors)
        {
          responseError.Add(new ErrorResponse
          {
            ErrorDescription = error.ErrorMessage
          });
          {
            badRequest = new BadRequestObjectResult(responseError);
            return true;
          }
        }
      }

      badRequest = null;
      return false;
    }
  }
}
