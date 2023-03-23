using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using _66.WebApi_Cars.Helpers;
using DataAccess.Generic;
using Entities.Domain;
using Entities.Requests;
using Entities.Requests.Validators;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace _66.WebApi_Cars.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IGenericRepository<User> _genericRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;
		private readonly ILogger<UsersController> _logger;

		public UsersController(IGenericRepository<User> genericRepository, IConfiguration configuration, IUnitOfWork unitOfWork, ILogger<UsersController> logger)
		{
			_genericRepository = genericRepository;
			_configuration = configuration;
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		[HttpPost]
		[Route("authenticate")]
		public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
		{
			_logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(request));

			var user = (await _genericRepository.GetAsync(x => x.Email == request.Email && x.Password == request.Password, null, "Role")).FirstOrDefault();

			if (user == null)
			{
				var responseMessage = "Usuario o contraseña no válido";
				
				_logger.LogInformation(responseMessage);
				return BadRequest(responseMessage);
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Nombre),
					new Claim(ClaimTypes.Role, user.Role.Descripcion),
					new Claim(ClaimTypes.Email, user.Email)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
				Audience = _configuration["JWT:ValidAudience"],
				Issuer = _configuration["JWT:ValidIssuer"]
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			var authenticateResponse = new AuthenticateResponse
			{
				Id = user.Id,
				Nombre = user.Nombre,
				Email = user.Email,
				Token = tokenHandler.WriteToken(token)
			};

			_logger.LogInformation(System.Text.Json.JsonSerializer.Serialize(authenticateResponse));

			return Ok(authenticateResponse);

		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
		{
			var validator = new RegisterUserRequestValidator();
			var result = await validator.ValidateAsync(request);

			if (ValidationErrorsHelper.CheckValidationErrors(result, out var badRequest)) return badRequest;

			var userExists = (await _genericRepository.GetAsync(x => x.Email == request.Email)).FirstOrDefault();
			if (userExists != null)
			{
				return BadRequest($"El usuario {request.Email} ya existe en BD");
			}

			var user = new User
			{
				Email = request.Email,
				RoleId = request.Rol,
				Nombre = request.Nombre,
				Password = request.Password,
			};

			var created = await _genericRepository.CreateAsync(user);
			if (created) _unitOfWork.Commit();

			return Created("", new { Response = StatusCode(201) });
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		[Route("update/{id}/role/{roleId}")]
		public async Task<IActionResult> UpdateUserRole(int id, int roleId)
		{
			var userExists = (await _genericRepository.GetAsync(x => x.Id == id)).FirstOrDefault();
			if (userExists == null)
			{
				return BadRequest($"No se ha encontrado usuario con el id {id}");
			}

			userExists.RoleId = roleId;

			var updated = await _genericRepository.UpdateAsync(userExists);

			if (updated) _unitOfWork.Commit();

			return Ok();
		}
	}
}
