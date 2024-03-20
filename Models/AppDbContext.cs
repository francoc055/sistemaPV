using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemPV.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Cliente> DbCliente { get; set; }
        public DbSet<Vianda> DbVianda { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; DataBase=appviandas; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
