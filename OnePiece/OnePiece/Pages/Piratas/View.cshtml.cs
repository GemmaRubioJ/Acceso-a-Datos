using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnePiece.Modelos;
using OnePiece.Service;

namespace OnePiece.Pages.Piratas
{
    public class ViewModel : PageModel
    {
        public readonly IPirataRepositorioBD pirataRepositorioBD;

        public Pirata pirata {  get; set; }

        public ViewModel(IPirataRepositorioBD pirataRepositorioBD)
        {
            this.pirataRepositorioBD = pirataRepositorioBD;

        }

        public void OnGet(int id)
        {
            pirata = pirataRepositorioBD.GetPirata(id);
        }
    }
}
