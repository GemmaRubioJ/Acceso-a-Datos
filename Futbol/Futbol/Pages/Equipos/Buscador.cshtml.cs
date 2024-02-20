using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Service;

namespace Futbol.Pages.Equipos
{
    public class BuscadorModel : PageModel
    {
        private readonly IEquipoRepositorioBD equipoRepositorioBD;

        public IEnumerable<Equipo> Equipos;

        [BindProperty(SupportsGet = true)]
        public Categoria ElementoABuscar {  get; set; }

        public BuscadorModel(IEquipoRepositorioBD equipoRepositorioBD)
        {
            this.equipoRepositorioBD = equipoRepositorioBD;

        }


        public void OnGet()
        {
            Equipos = equipoRepositorioBD.FindEquiposPorCategoria(ElementoABuscar);
        }
    }
}
