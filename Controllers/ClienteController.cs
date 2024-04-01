using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using S02LaboratorioDSWI_01.Models;


namespace S02LaboratorioDSWI_01.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IConfiguration _config;

        public ClienteController(IConfiguration config)
        {
            _config = config;
        }

        List<Cliente> obtenerClientes()
        {
            List<Cliente> lstClientes = new List<Cliente>();
            SqlConnection cn = new SqlConnection(_config["ConnectionStrings:sql"].ToString());
            //Definimos un SqlCommand y su CommandType 
            SqlCommand cmd = new SqlCommand("usp_listaCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Abrimos conexión
            cn.Open();

            //Ejecutamos el SqlCommand
            SqlDataReader dr = cmd.ExecuteReader();

            //Recuperamos los valores del SqlDataReader
            while (dr.Read())
            {
                Cliente reg = new Cliente();
                reg.CodigoCliente = dr.GetString("IdCliente");
                reg.NombreCliente = dr.GetString("NombreCia");
                reg.Direccion = dr.GetString("Direccion");
                reg.DescripcionPais = dr.GetString("NombrePais");
                reg.Telefono = dr.GetString("Telefono");

                lstClientes.Add(reg);

            }

            //Cerramos el SqlDataReader y la conexión a la BD
            dr.Close();
            cn.Close();
            return lstClientes;

        }

        public IActionResult ListarClientes()
        {
            List<Cliente> lista = obtenerClientes();
            return View(lista);
        }
    }
}
