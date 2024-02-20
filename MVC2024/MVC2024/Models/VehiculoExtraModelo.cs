namespace MVC2024.Models
{
    public class VehiculoExtraModelo
    {
        public int Id { get; set; }
        public int ExtraId { get; set; }
        public ExtraModelo Extra {  get; set; }
        public int VehiculoId { get; set; }
        public VehiculoModelo Vehiculo { get; set; }
    }
}
