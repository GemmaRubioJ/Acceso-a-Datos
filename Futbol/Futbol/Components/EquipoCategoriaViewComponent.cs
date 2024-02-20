using Microsoft.AspNetCore.Mvc;
using Service;

namespace Futbol.Components
{
    public class EquipoCategoriaViewComponent : ViewComponent 
    {
        public IEquipoRepositorioBD EquipoRepositorioBD { get; }


        public EquipoCategoriaViewComponent( IEquipoRepositorioBD equipoRepositorioBD)
        {
            EquipoRepositorioBD = equipoRepositorioBD;
        }

        public IViewComponentResult Invoke()
        {
            var resultado = EquipoRepositorioBD.EquiposPorCategoria();
            return View(resultado);
        }
    }
}
