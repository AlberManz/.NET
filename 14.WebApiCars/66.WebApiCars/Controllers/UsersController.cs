using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _66.WebApiCars.Helpers;
using DataAccess.Generic;
using Entities.Domain;
using Entities.Requests;
using Entities.Requests.Validators;
using Entities.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace _66.WebApiCars.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IGenericRepository<User> _genericRepository;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
    {
      _unitOfWork = unitOfWork;
      _configuration = configuration;
      _genericRepository = genericRepository;
    }

    [HttpPost]

    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
    {
      var user = (await _genericRepository.GetAsync(
        x => x.Email == request.Email && x.Password == request.Password,
        null,
        "Role"))
        .FirstOrDefault();

      if (user == null)
      {
        return BadRequest("Usuario o contraseña incorrecta");
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Nombre),
          new Claim(ClaimTypes.Role, user.Role.Description)
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        Audience = _configuration["JWT:ValidAudience"],
        Issuer = _configuration["JWT:ValidIssuer"]
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return Ok(new AuthenticateResponse
      {
        Id = user.Id,
        Nombre = user.Nombre,
        Email = user.Email,
        Token = tokenHandler.WriteToken(token)
      });

    }

    [HttpPost]
    [Route("register-user")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
      var validator = new RegisterUserRequestValidator();
      var result = await validator.ValidateAsync(request);

      if (ValidationErrorsHelper.CheckValidationResult(result, out var badRequest)) return badRequest;

      var userExists = (await _genericRepository.GetAsync(
        x => x.Email == request.Email || x.Nombre == request.Nombre)).FirstOrDefault();

      if (userExists != null)
      {
        return BadRequest($"El usuario {request.Email} ya existe");
      }

      var user = new User
      {
        RoleId = request.Rol,
        Nombre = request.Nombre,
        Email = request.Email,
        Password = request.Password
      };

      var created = await _genericRepository.CreateAsync(user);
      if (created) _unitOfWork.Commit();

      return Created("", new { Response = StatusCode(201) });
    }
  }
}
