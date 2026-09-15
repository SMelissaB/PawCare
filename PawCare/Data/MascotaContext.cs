using Microsoft.EntityFrameworkCore;
using PawCare.Models;

namespace PawCare.Data
{
    public class MascotaContext : DbContext
    {
        public MascotaContext(DbContextOptions<MascotaContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }

    }
}
