using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PawCare.Data;
using PawCare.Models;
using System.Data;

namespace PawCare.Controllers
{
    public class MascotaController : Controller
    {
        private readonly MascotaContext _context;

        public MascotaController(MascotaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(ObtenerMascotas());
        }
 

        // CREATE - guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = (SqlConnection)_context.Database.GetDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertarMascota", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@NombreMascota", SqlDbType.VarChar, 100)).Value = mascota.NombreMascota;
                        cmd.Parameters.Add(new SqlParameter("@NombreDueno", SqlDbType.VarChar, 100)).Value = mascota.NombreDueno;
                        cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 50)).Value = mascota.Tipo;
                        cmd.Parameters.Add(new SqlParameter("@Edad", SqlDbType.Int)).Value = mascota.Edad;
                        cmd.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20)).Value = mascota.Telefono;
                        cmd.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 255)).Value =
                            string.IsNullOrEmpty(mascota.Observaciones) ? (object)DBNull.Value : mascota.Observaciones;

                        if (con.State != ConnectionState.Open) con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View("Index", ObtenerMascotas());
        }

        private List<Mascota> ObtenerMascotas()
        {
            var lista = new List<Mascota>();
            using (SqlConnection con = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spListarMascotas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (con.State != ConnectionState.Open) con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Mascota
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                NombreMascota = dr["NombreMascota"].ToString(),
                                NombreDueno = dr["NombreDueno"].ToString(),
                                Tipo = dr["Tipo"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Telefono = dr["Telefono"].ToString(),
                                Observaciones = dr["Observaciones"] == DBNull.Value ? null : dr["Observaciones"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
