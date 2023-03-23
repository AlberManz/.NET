using System.Runtime.CompilerServices;
using _65.API.Helpers;
using DataAccess.Generic;
using Entities.Domain;
using Entities.Requests;
using Entities.Requests.Validators;
using Entities.Responses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _65.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArtistasController : ControllerBase
  {

    private readonly IGenericRepository<Artista> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;


    public ArtistasController(IGenericRepository<Artista> genericRepository, IUnitOfWork unitOfWork)
    {
      _genericRepository = genericRepository;
      _unitOfWork = unitOfWork;
    }

    // GET: api/<ArtistasController>
    /// <summary>
    /// Obtiene todos los artistas
    /// </summary>
    /// <returns>Lista de artistas</returns>

    [HttpGet]
    public async Task<IEnumerable<Artista>> Get()
    {
      var lista1 = await _genericRepository.GetAsync();

      var lista2 = await _genericRepository.GetAsync(x => true,
        x => x.OrderByDescending(y => y.Id),
        "Albumes");

      var lista3 = await _genericRepository.GetAsync(
        null,
        x => x.OrderByDescending(y => y.Id),
        "Albumes");

      var lista4 = await _genericRepository.GetAsync(
        orderBy: x => x.OrderByDescending(y => y.Nombre),
        includeProperties: "Albumes");

      return lista1;
    }

    // GET api/<ArtistasController>/5
    /// <summary>
    /// Obtiene un artista por id
    /// </summary>
    /// <param name="id">Identificador del artista</param>
    /// <returns>Artista encontrado</returns>
    [HttpGet("{id}")]
    public async Task<Artista?> Get(int id)
    {
      return ((await _genericRepository.GetAsync(x => x.Id == id, null, ""))).FirstOrDefault();
    }


    // POST api/<ArtistasController>
    /// <summary>
    ///  Crea un artista
    /// </summary>
    /// <param name="artistaRequest">Artista a crear</param>
    /// <returns>Status Code 201 - Ruta del artista creado</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArtistaRequest artistaRequest)
    {
      var validator = new CreateArtistaValidators();
      var result = await validator.ValidateAsync(artistaRequest);

      if (ValidationErrorsHelper.CheckValidationResult(result, out var badRequest)) return badRequest;

      var artistaExistente =
        (await _genericRepository.GetAsync(x => x.Nombre == artistaRequest.Nombre)).FirstOrDefault();

      if (artistaExistente != null)
      {
        return BadRequest(new ErrorResponse
        {
          ErrorDescription = $"Ya existe el artista {artistaRequest.Nombre}"
        });
      }

      var artista = new Artista
      {
        Nombre = artistaRequest.Nombre,
        Edad = artistaRequest.Edad,
        Pais = artistaRequest.Pais
      };

      var created = await _genericRepository.CreateAsync(artista);

      if (created)
      {
        _unitOfWork.Commit();
      }

      return Created($"/api/artistas/{artista.Id}", new { Response = StatusCode(201) });
    }



    // PUT api/<ArtistasController>/5
    /// <summary>
    /// Actualiza un artista
    /// </summary>
    /// <param name="id">id del artista a actualizar</param>
    /// <param name="albumRequest"></param>
    /// <returns>Status Code 200</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateArtistaRequest artistaRequest)
    {

      var validator = new CreateArtistaRequest();
      var result = await validator.

      if (ValidationErrorsHelper.CheckValidationResult(result, out var badRequest)) return badRequest;

      var artista = new Artista
      {
        Id = id,
        Nombre = artistaRequest.Nombre,
        Edad = artistaRequest.Edad,
        Pais = artistaRequest.Pais,
      };

      var updated = await _genericRepository.UpdateAsync(artista);

      if (updated) _unitOfWork.Commit();

      return Ok();
    }

    // DELETE api/<ArtistasController>/5
    /// <summary>
    /// Elimina un artista
    /// </summary>
    /// <param name="id">id del artista a eliminar</param>
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
