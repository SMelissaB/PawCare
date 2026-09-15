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
            return View(await _context.Mascotas.ToListAsync());
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
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }
    }
}
