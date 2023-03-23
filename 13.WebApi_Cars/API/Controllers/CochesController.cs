using _66.WebApi_Cars.Helpers;
using DataAccess.Generic;
using Entities.Domain;
using Entities.Requests;
using Entities.Requests.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _66.WebApi_Cars.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CochesController : ControllerBase
  {
    private readonly IGenericRepository<Coche> _genericRepositoryCoches;
    private readonly IGenericRepository<User> _genericRepositoryUsers;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CochesController> _logger;

    public CochesController(IGenericRepository<Coche> genericRepositoryCoches, IUnitOfWork unitOfWork, IGenericRepository<User> genericRepositoryUsers, ILogger<CochesController> logger)
    {
      _genericRepositoryCoches = genericRepositoryCoches;
      _unitOfWork = unitOfWork;
      _genericRepositoryUsers = genericRepositoryUsers;
      _logger = logger;
    }

    // GET: api/<CochesController>
    [HttpGet]
    public async Task<IEnumerable<Coche>> Get()
    {
      return await _genericRepositoryCoches.GetAsync(
        x => true,
        x => x.OrderByDescending(y => y.Id));
    }

    // POST api/<CochesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterCocheRequest requestCoche)
    {
      _logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(requestCoche));

      var validator = new RegisterCocheRequestValidator();
      var result = await validator.ValidateAsync(requestCoche);

      if (ValidationErrorsHelper.CheckValidationErrors(result, out var badRequest)) return badRequest;

      var cocheExists =
        (await _genericRepositoryCoches.GetAsync(
          x => x.Modelo == requestCoche.Modelo &&
               x.Marca == requestCoche.Marca &&
               x.Version == requestCoche.Version))
        .FirstOrDefault();

      if (cocheExists != null)
      {
        return BadRequest($"{requestCoche.Marca} {requestCoche.Modelo}, versión {requestCoche.Version} ya existe en la BD");
      }

      var newCoche = new Coche
      {
        Modelo = requestCoche.Modelo,
        Marca = requestCoche.Marca,
        Version = requestCoche.Version
      };

      var created = await _genericRepositoryCoches.CreateAsync(newCoche);
      if (created) _unitOfWork.Commit();

      _logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(newCoche));

      return Created("", new { Response = StatusCode(201) });
    }

    // POST api/<CochesController>
    [HttpPost]
    [Route("asignar-coche-usuario")]
    public async Task<IActionResult> AsignarCocheUsuario([FromBody] AsignarCocheUsuarioRequest request)
    {
      _logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(request));

      var userExists = (await _genericRepositoryUsers.GetAsync(x => x.Id == request.IdUsuario)).FirstOrDefault();
      if (userExists == null)
      {
        return BadRequest($"No se ha encontrado un usuario con el id {request.IdUsuario}");
      }

      var cocheExists = (await _genericRepositoryCoches.GetAsync(x => x.Id == request.IdCoche)).FirstOrDefault();
      if (cocheExists == null)
      {
        return BadRequest($"No existe un coche con el id {request.IdCoche}");
      }

      userExists.CocheId = request.IdCoche;

      var updated = await _genericRepositoryUsers.UpdateAsync(userExists);
      if (updated) _unitOfWork.Commit();

      _logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(userExists));

      return Ok();
    }
  }
}
