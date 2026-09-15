using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawCare.Data;
using PawCare.Models;

namespace PawCare.Controllers
{
    public class MascotaController : Controller
    {
        private readonly MascotaContext _context;

        public MascotaController(MascotaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mascotas = await _context.Mascotas
                .FromSqlRaw("EXEC spListarMascotas")
                .ToListAsync();

            return View(mascotas);
        }

        // CREATE - formulario
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC spInsertarMascota @NombreMascota = {0}, @NombreDueno = {1}, @Tipo = {2}, @Edad = {3}, @Telefono = {4}, @Observaciones = {5}",
                    mascota.NombreMascota,
                    mascota.NombreDueno,
                    mascota.Tipo,
                    mascota.Edad,
                    mascota.Telefono,
                    (object)mascota.Observaciones ?? DBNull.Value
                );

                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }
    }
}
