using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entities.Requests.Validators
{
  public class RegisterCocheRequestValidator : AbstractValidator<RegisterCocheRequest>
  {
    public RegisterCocheRequestValidator()
    {
      RuleFor(x => x.Marca).NotEmpty().NotNull();
      RuleFor(x => x.Modelo).NotEmpty().NotNull();
      RuleFor(x => x.Version).NotEmpty().NotNull();
    }
  }
}
