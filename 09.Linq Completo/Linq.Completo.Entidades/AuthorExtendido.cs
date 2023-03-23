using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq.Completo.Entidades
{
  public class AuthorExtendido : Author
  {
    public AuthorExtendido(int authorId, string name, int numeroLibrosPublicado) : base(authorId, name)
    {
      NumeroLibrosPublicado = numeroLibrosPublicado;
    }

    public AuthorExtendido(int authorId, string name, string tituloLibro) : base(authorId, name)
    {
      TituloLibro = tituloLibro;
    }

    public int NumeroLibrosPublicado { get; set; }
    public string TituloLibro { get; set; }
  }
}
