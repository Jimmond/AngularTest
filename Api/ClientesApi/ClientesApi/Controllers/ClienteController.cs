using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClientesApi.Models;

namespace ClientesApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public ClienteController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpGet]
		public JsonResult Get()
		{
			string query = @"
					select ClienteID, Nombre, Apellido, Direccion, Foto from TBL_CLIENTE";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("ClientesAppCon");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);

					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult(table);
		}

		[HttpPost]
		public JsonResult Post(Cliente cli)
		{
			string query = @"
					insert into TBL_CLIENTE values 
					('" + cli.Nombre + @"','" + cli.Apellido + @"','" + cli.Direccion + @"','" + cli.Foto + @"')
					";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("ClientesAppCon");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);

					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult("Agregado Satisfactoriamente");
		}
		[HttpPut]
		public JsonResult Put(Cliente cli)
		{
			string query = @"
					update TBL_CLIENTE set Nombre = '" + cli.Nombre + @"', 
					Apellido = '" + cli.Apellido + @"',
					Direccion= '" + cli.Direccion + @"',
					Foto= '" + cli.Foto + @"'
					where ClienteId = '"+cli.ClienteID+@"'
					";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("ClientesAppCon");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);

					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult("Actualizado  Satisfactoriamente");
		}

		[HttpDelete("{id}")]
		public JsonResult Delete(int id)
		{
			string query = @"
					delete from TBL_CLIENTE
					where ClienteId = '" + id + @"'
					";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("ClientesAppCon");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);

					myReader.Close();
					myCon.Close();
				}
			}
			return new JsonResult("Borrado  Satisfactoriamente");
		}
	}
}
