using System.Text.RegularExpressions;
using FluentValidation;

namespace Entities.Requests.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
  private const int PasswordMinLength = 4;
  public RegisterUserRequestValidator()
  {
    RuleFor(x => x.Nombre)
      .NotEmpty()
      .NotNull();
    RuleFor(x => x.Email)
      .EmailAddress();
    RuleFor(x => x.Password)
      .MinimumLength(PasswordMinLength)
      .Must(HasValidPassword)
      .WithMessage($"El password debe tener un mínimo de {PasswordMinLength} caracteres, una mayúscula y un dígito");
  }

  private bool HasValidPassword(string password)
  {
    var lowercase = new Regex("[a-z]+");
    var uppercase = new Regex("[A-Z]+");
    var digit = new Regex("(\\d)+");

    return (lowercase.IsMatch(password) && uppercase.IsMatch(password) && digit.IsMatch(password));
  }
}