using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnePiece.Modelos;
using OnePiece.Service;

namespace OnePiece.Pages.Piratas
{
    public class InsertModel : PageModel
    {
        public IPirataRepositorioBD pirataRepositorioBD;
        public Pirata pirataNuevo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IFormFile Photo { get; set; }

        public InsertModel (IPirataRepositorioBD pirataRepositorioBD, IWebHostEnvironment WebHostEnvironment)
        {
            this.pirataRepositorioBD = pirataRepositorioBD;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int? id )
        {
            if (id.HasValue)
            {
                pirataNuevo = pirataRepositorioBD.GetPirata (id.Value);
            }
            else
            {
                pirataNuevo = new Pirata();
            } return Page();
        }

        public IActionResult OnPost(Pirata pirataNuevo, IFormFile Photo)
        {
            pirataRepositorioBD.Add(pirataNuevo);
            return RedirectToPage("Index");
        }

    }
}
