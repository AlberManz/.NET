using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
	public class AsignarCocheUsuarioRequest
	{
		public int IdUsuario { get; set; }
		public int IdCoche { get; set; }
	}
}
