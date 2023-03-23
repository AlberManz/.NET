using System.ComponentModel;
using System.Text;
using DataAccess.Generic;
using DataAccess.Repositories;
using Entities.Domain;
using Entities.Requests;
using Entities.Requests.NewFolder1;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _65.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AlbumesController : ControllerBase
  {

    private readonly IGenericRepository<Album> _genericRepository; // Traemos los datos genéricos de Album a través de genericRepository
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAlbumesRepository _albumesRepository;
    public AlbumesController(IGenericRepository<Album> genericRepository, IUnitOfWork unitOfWork, IAlbumesRepository albumesRepository) // Generamos un constructor para cargar los datos
    {
      _genericRepository = genericRepository;
      _unitOfWork = unitOfWork;
      _albumesRepository = albumesRepository;
    }


    // GET: api/<ValuesController>
    /// <summary>
    /// Obtiene todos los álbumes
    /// </summary>
    /// <returns>Lista de álbumes</returns>
    [HttpGet]
    public async Task<IEnumerable<Album>> Get()
    {

      // DIFERENTES OPCIONES EQUIVALENTES

      // lista 1 muestra los albums, sin los datos del artista que se le pasa con la propiedad includeProperties
      // lista 2 le pasamos todas las propiedades incluidas en el método (x=>true nos los trae todos)
      // lista 3 poniendo uno de las propiedades a null nos permite no tenerla en cuenta
      // lista 4 poniendo el nombre de la propiedad y ":" marcamos qué propiedades vamos a pasar 

      var lista1 = await _genericRepository.GetAsync();

      var lista2 = await _genericRepository.GetAsync(
        x => true, // "x => true" nos va a traer todos
        x => x.OrderByDescending(y => y.Precio), // y lo ordenamos.
        "Artista"); // "Artista" nos va a dar el id y el nombre por cómo está configurado el genericRepository que nos hemos traído

      var lista3 = await _genericRepository.GetAsync(null,
        x => x.OrderByDescending(y => y.Precio),
        "Artista");

      var lista4 = await _genericRepository.GetAsync(orderBy: x => x.OrderByDescending(y => y.Precio),
        includeProperties: "Artista");

      return lista4;

    }

    // GET api/<ValuesController>/5
    /// <summary>
    /// Obtiene un álbum por id
    /// </summary>
    /// <param name="id">Identificador del álbum</param>
    /// <returns>Album encontrado</returns>
    [HttpGet("{id}")]
    public async Task<Album> Get(int id)
    {
      var listaAlbumes = await _genericRepository.GetAsync(x => x.Id == id,
        includeProperties: "Artista");

      return listaAlbumes.FirstOrDefault();
    }


    /// <summary>
    /// Lista de álbumes agrupados por cada artista
    /// </summary>
    /// /// <param name="NombreArtista">Nombre del artista</param>
    /// <returns>Devuelve los artistas con sus álbumes agrupados</returns>
    [HttpGet("albumes-agrupados")]
    public async Task<IEnumerable<AlbumesAgrupadosResponse>> AlbumesAgrupados(string? NombreArtista)
    {
      var listadoAlbumesAgrupados = await _albumesRepository.GetAlbumesAgrupados(NombreArtista);
      return listadoAlbumesAgrupados;
    }


    // POST api/<ValuesController>
    /// <summary>
    ///  Crea un álbum
    /// </summary>
    /// <param name="album">Álbum a crear</param>
    /// <returns>Status Code 201 - Creado</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAlbumRequest albumRequest) // IActionResult es porque vamos a devolver un StatusCode
    {
      var validator = new CreateAlbumValidators();
      var result = await validator.ValidateAsync(albumRequest); // Esto nos da un array con los errores si los hubiera

      if (!result.IsValid)
      {
        var responseError = new List<ErrorResponse>(); // Hemos creado una class ErrorResponse con una propiedad ErrorDescription
        foreach (var error in result.Errors) // recorremos el array con los errores 
        {
          responseError.Add(new ErrorResponse // Añadimos un nuevo error diciendo que meta en ErrorDescription lo que viene en error.Message
          {
            ErrorDescription = error.ErrorMessage
          });
        }
        return BadRequest(responseError);
      }

      var albumExistente =
        (await _genericRepository.GetAsync(x => x.Titulo == albumRequest.Titulo)).FirstOrDefault();

      if (albumExistente != null)
      {
        return BadRequest(new ErrorResponse
        {
          ErrorDescription = $"Ya existe un álbum con el título {albumRequest.Titulo}"
        });
      }

      var album = new Album
      {
        ArtistaId = albumRequest.ArtistaId,
        Titulo = albumRequest.Titulo,
        Precio = albumRequest.Precio,
        Anio = albumRequest.Anio,
      };

      var created = await _genericRepository.CreateAsync(album);

      if (created)
      {
        _unitOfWork.Commit();
      }

      return Created("Album creado", new { Response = StatusCode(201) });
    }

    // PUT api/<ValuesController>/5
    /// <summary>
    /// Actualiza un álbum
    /// </summary>
    /// <param name="id">id del álbum a actualizar</param>
    /// <param name="albumRequest"></param>
    /// <returns>Status Code 200</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAlbumRequest albumRequest)
    {

      var album = new Album
      {
        Id = id,
        ArtistaId = albumRequest.ArtistaId,
        Titulo = albumRequest.Titulo,
        Precio = albumRequest.Precio,
        Anio = albumRequest.Anio
      };


      var updated = await _genericRepository.UpdateAsync(album);

      if (updated) _unitOfWork.Commit();

      return Ok();

    }

    // DELETE api/<ValuesController>/5
    /// <summary>
    /// Elimina un álbum
    /// </summary>
    /// <param name="id">id del álbum a eliminar</param>
    /// <returns>Status Code 200</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var deleted = await _genericRepository.DeleteAsync(x => x.Id == id);

      if (deleted) _unitOfWork.Commit();

      return Ok();
    }
  }
}
