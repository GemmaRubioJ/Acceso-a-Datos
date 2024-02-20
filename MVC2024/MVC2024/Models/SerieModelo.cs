namespace MVC2024.Models
{
	public class SerieModelo
	{
        public int ID { get; set; }
		public string NomSerie { get; set; }
        public MarcaModelo Marca { get; set; }
		public int MarcaId { get; set; }

    }
}
