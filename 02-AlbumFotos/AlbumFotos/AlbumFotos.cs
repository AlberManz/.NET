using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlbumFotos
{
  public class AlbumFotos
  {
    private int numPaginas;

    public AlbumFotos()
    {
      numPaginas = 16;
    }

    public AlbumFotos(int numPaginas)
    {
      this.numPaginas = numPaginas;
    }

    public int GetNumberPages()
    {
      return numPaginas;
    }
  }
}
