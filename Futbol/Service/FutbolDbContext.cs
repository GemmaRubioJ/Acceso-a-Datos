using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Service
{
    public class FutbolDbContext : DbContext
    {

        public FutbolDbContext(DbContextOptions<FutbolDbContext> options) : base(options) { }
        public DbSet<Equipo> equipo { get; set; }

        public FutbolDbContext()
        {

        }
    }
}
