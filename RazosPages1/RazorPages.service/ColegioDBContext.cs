using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages.modelos;

namespace RazorPages.services
{
    public class ColegioDBContext : DbContext
    {
        public ColegioDBContext(DbContextOptions<ColegioDBContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }

    }

}
