using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Models
{
	public class Cliente
	{
		public int ClienteID { get; set; }

		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
		public string Foto { get; set; }


	}
}
