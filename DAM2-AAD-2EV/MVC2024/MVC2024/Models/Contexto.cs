using Microsoft.EntityFrameworkCore;

namespace MVC2024.Models
{
	public class Contexto : DbContext
	{
        public Contexto(DbContextOptions<Contexto> options) : base (options)
        {
            
            
        }
        //el dbset es como un enumerable o una lista de objetos de tipo MarcaModelo
		public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }

	}
}
