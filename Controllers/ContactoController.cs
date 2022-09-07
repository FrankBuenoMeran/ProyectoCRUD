using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoCRUD.Controllers
{
    public class ContactoController : Controller
    {
        private static string conexion=ConfigurationManager.ConnectionStrings["cadena"].ToString();
        private static List<Contacto> olista = new List<Contacto>();
        // GET: Contacto
        public ActionResult Inicio()
        {
            olista = new List<Contacto>();
            using (SqlConnection oconexion = new SqlConnection(conexion) ) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACTO", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (
                        dr.Read()) 
                    {
                        Contacto NuevoContacto = new Contacto();
                        NuevoContacto.IdContacto =Convert.ToInt32( dr["IdContacto"].ToString());
                        NuevoContacto.Nombre = dr["Nombre"].ToString();
                        NuevoContacto.Apellidos = dr["Apellidos"].ToString();
                        NuevoContacto.Telefono = dr["Telefono"].ToString();
                        NuevoContacto.Correo = dr["Correo"].ToString();
                        olista.Add(NuevoContacto);
                    }
                }
            }
          return View(olista);
        }
    }
}