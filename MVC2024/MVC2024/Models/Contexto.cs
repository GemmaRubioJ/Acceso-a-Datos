using Microsoft.EntityFrameworkCore;
using static MVC2024.Controllers.VehiculoController;
using MVC2024.Models;

namespace MVC2024.Models
{
	public class Contexto : DbContext
	{
        public Contexto(DbContextOptions<Contexto> options) : base (options)
        {
            
            
        }
        // @Override Al crear los modelos de aqui abajo sobreescribe lo que le digamos. En este caso, que VehiculoTotal no tiene PK
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehiculoTotal>(
                eb =>
                {
                    eb.HasNoKey();
                });
        }



        //el dbset es como un enumerable o una lista de objetos de tipo MarcaModelo
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculo { get; set;}
        //declaramos un dbset de la nueva clase de objetos de la consulta sql
        public DbSet<VehiculoTotal> VistaTotal { get; set; }
        public DbSet<MVC2024.Models.ClienteModelo>? ClienteModelo { get; set; }
        public DbSet<ExtraModelo> Extras { get; set; }

        public DbSet<VehiculoExtraModelo> ExtraModelo { get; set; }



    }
}
