using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entities.DataContext;
using Entities.Responses;
using Microsoft.EntityFrameworkCore;
using Console = System.Console;

namespace DataAccess.Repositories
{
  public class AlbumesRepository : IAlbumesRepository
  {
    private readonly WebApiDbContext _context;

    public AlbumesRepository(WebApiDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<AlbumesAgrupadosResponse>> GetAlbumesAgrupados(string? NombreArtista)
    {
      var query = (from artista in _context.Artistas
                   join album in _context.Albumes on artista.Id equals album.ArtistaId
                   group album by new { album.ArtistaId, NombreArtista = artista.Nombre } into groupedAlbumes
                   select new AlbumesAgrupadosResponse
                   {
                     IdArtista = groupedAlbumes.Key.ArtistaId,
                     NombreArtista = groupedAlbumes.Key.NombreArtista,
                     NumeroAlbumes = groupedAlbumes.Count()
                   });

      if (!string.IsNullOrEmpty(NombreArtista))
      {
        query = query.Where(x => x.NombreArtista == NombreArtista);
      }

      return await query.ToListAsync();
    }
  }
}
