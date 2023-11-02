using MAS_2.Models;
using Microsoft.EntityFrameworkCore;

namespace MAS_2.Data
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Zgloszenie> Zgloszenies { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<MateracLateksowy> MateracLateksowy { get; set; }
    }
}
