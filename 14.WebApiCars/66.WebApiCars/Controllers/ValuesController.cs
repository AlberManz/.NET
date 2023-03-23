using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _66.WebApiCars.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // GET: api/<ValuesController>
    [HttpGet]
    [Authorize(Roles = "Admin,Operador")] // Aquí podemos hacer pruebas cambiando el role para controlar quién pasa dependiendo del token. En este caso los dos
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")] // Solo los admin podrían entrar aquí
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous] // Cualquier persona sin estar logueada ni registrada
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
