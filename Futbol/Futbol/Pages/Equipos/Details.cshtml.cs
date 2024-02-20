using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Service;

namespace Futbol.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        public readonly IEquipoRepositorioBD equipoRepositorioBD;

        public Equipo equipo {  get; set; }

        public DetailsModel (IEquipoRepositorioBD equipoRepositorioBD)
        {
            this.equipoRepositorioBD = equipoRepositorioBD;
        }

        public void OnGet(int id)
        {
            equipo = equipoRepositorioBD.GetEquipo(id);
        }
    }
}
