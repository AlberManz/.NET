using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entities.Requests.NewFolder1
{
  public class CreateAlbumValidators : AbstractValidator<CreateAlbumRequest>
  {
    public CreateAlbumValidators()
    {
      RuleFor(x => x.Anio)
        .GreaterThan(1000)
        .LessThanOrEqualTo(DateTime.Now.Year);

      RuleFor(x => x.ArtistaId).GreaterThan(0);

      RuleFor(x => x.Titulo).Length(3, 250);

    }
  }
}
