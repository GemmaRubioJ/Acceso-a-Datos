using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnePiece.Modelos;
using OnePiece.Service;

namespace OnePiece.Pages.Piratas
{
    public class IndexModel : PageModel
    {
        private readonly IPirataRepositorioBD pirataRepositorioBD;
        public IEnumerable<Pirata> Piratas;
        public Pirata pirata;
        public string elementoABuscar;

        public IndexModel(IPirataRepositorioBD pirataRepositorioBD, IEnumerable<Pirata> piratas)
        {
            this.pirataRepositorioBD = pirataRepositorioBD;
            Piratas = piratas;
        }

        public void OnGet(string elementoABuscar = "")
        {
            Piratas = pirataRepositorioBD.Busqueda(elementoABuscar);
        }

    }
}
