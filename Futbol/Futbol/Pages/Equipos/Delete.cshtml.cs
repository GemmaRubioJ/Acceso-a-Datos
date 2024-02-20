using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Service;

namespace Futbol.Pages.Equipos
{
    public class DeleteModel : PageModel
    {
        public readonly IEquipoRepositorioBD equipoRepositorioBD;

        [BindProperty]
        public Equipo equipo { get; set; } 

        public DeleteModel(IEquipoRepositorioBD equipoRepositorioBD)
        {
            this.equipoRepositorioBD = equipoRepositorioBD;
        }

        public IActionResult OnGet(int id)
        {
            equipo = equipoRepositorioBD.GetEquipo(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            equipoRepositorioBD.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
