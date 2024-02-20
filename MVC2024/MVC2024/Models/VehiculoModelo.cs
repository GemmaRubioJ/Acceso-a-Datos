using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2024.Models
{
	public class VehiculoModelo
	{
		public int Id { get; set; }
		public string Matricula { get; set; }
		public string Color { get; set; }

		public SerieModelo Serie { get; set; }
		public int serieId { get; set; }
		[NotMapped]
		public List<int> ExtraSeleccionado { get; set; }
		public List<VehiculoExtraModelo> ExtraModelo { get; set; }
        

    }
}
