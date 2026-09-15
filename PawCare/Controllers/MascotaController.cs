using Microsoft.AspNetCore.Mvc;
using PawCare.Data;

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
            var mascotas = _context.Mascotas.ToList();
            return View(mascotas);
        }

    }
}
