using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
	public class RegisterUserRequest
	{
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Rol { get; private set; }

		public RegisterUserRequest()
		{
			Rol = 2;
		}
	}
}
