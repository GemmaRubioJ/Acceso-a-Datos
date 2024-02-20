namespace MVC2024.Models
{
	public class MarcaModelo
	{
        public int ID { get; set; }
		public string NomMarca { get; set; }
		public List<SerieModelo> LasSeries { get; set; }

    }
}
