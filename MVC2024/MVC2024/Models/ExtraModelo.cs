using System.Security.Policy;

namespace MVC2024.Models
{
    public class ExtraModelo
    {
        public int Id { get; set; }
        public string NomExtra {  get; set; }
        public List<VehiculoExtraModelo> VehiculoExtras { get; set; }

    }
}
