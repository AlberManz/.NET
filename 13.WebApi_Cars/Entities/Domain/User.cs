using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int RoleId { get; set; }

		public Role Role { get; set; }

		public int? CocheId { get; set; }
		public Coche? Coche { get; set; }
	}
}
