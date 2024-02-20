using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Modelos;
using Service;

namespace Futbol.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IEquipoRepositorioBD equipoRepositorioBD;

        public IEnumerable<Equipo> Equipos;

        public IndexModel(IEquipoRepositorioBD equipoRepositorioBD)
        {
            this.equipoRepositorioBD = equipoRepositorioBD;

        }

        public void OnGet()
        {
            Equipos = equipoRepositorioBD.GetEquipos();
        }
    }
}
