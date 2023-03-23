using FluentValidation;
using System.Text.RegularExpressions;

namespace Entities.Requests.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
	private const int PasswordMinLength = 4;
	public RegisterUserRequestValidator()
	{
		RuleFor(x => x.Nombre).NotEmpty().NotNull();
		RuleFor(x => x.Email).EmailAddress();
		RuleFor(x => x.Password).MinimumLength(PasswordMinLength)
			.Must(HasValidPassword)
			.WithMessage($"El password no cumple los criterios longitud {PasswordMinLength} uso de minúsculas, mayúsculas y dígito");
	}

	private static bool HasValidPassword(string pw)
	{
		var lowercase = new Regex("[a-z]+");
		var uppercase = new Regex("[A-Z]+");
		var digit = new Regex("(\\d)+");

		return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw));
	}
}