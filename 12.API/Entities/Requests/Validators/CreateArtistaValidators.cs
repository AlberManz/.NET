using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entities.Requests.Validators
{
  public class CreateArtistaValidators : AbstractValidator<CreateArtistaRequest>
  {
    public CreateArtistaValidators()
    {
      RuleFor(x => x.Edad).GreaterThan(15).LessThan(100);
      RuleFor(x => x.Nombre).NotEmpty();
      RuleFor(x => x.Nombre).Length(3);
    }
  }
}
