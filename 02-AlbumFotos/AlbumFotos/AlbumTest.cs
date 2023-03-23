using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumFotos
{
  internal class AlbumTest
  {
    public static void Main()
    {
      AlbumFotos album = new AlbumFotos();
      Console.WriteLine(album.GetNumberPages());

      AlbumFotos album2 = new AlbumFotos(24);
      Console.WriteLine(album2.GetNumberPages());

      SuperAlbumFotos superAlbum = new SuperAlbumFotos();
      Console.WriteLine(superAlbum.GetNumberPages());
    }
  }
}
