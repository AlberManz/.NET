using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Responses;

namespace DataAccess.Repositories
{
  public interface IAlbumesRepository
  {
    Task<IEnumerable<AlbumesAgrupadosResponse>> GetAlbumesAgrupados(string? NombreArtista);
  }
}
