using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Modelos;
using Microsoft.AspNetCore.Hosting;

namespace Futbol.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly IEquipoRepositorioBD equipoRepositorioBD;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public Equipo equipo {  get; set; }
        public IFormFile Photo { get; set; }

        public EditModel(IEquipoRepositorioBD equipoRepositorioBD, IWebHostEnvironment webHostEnvironment)
        {
            this.equipoRepositorioBD = equipoRepositorioBD;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                equipo = equipoRepositorioBD.GetEquipo(id.Value);
            } else
            {
                equipo = new Equipo();
            }
            return Page();
        }

        public IActionResult OnPost(Equipo equipo, IFormFile Photo)
        {
            if(ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (equipo.escudo != null)
                    {
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, "images", equipo.escudo);
                        System.IO.File.Delete(filePath);
                    }
                    equipo.escudo = ProcessUploadedFile(Photo);
                } 

                if (equipo.Id > 0)
                {
                    equipoRepositorioBD.Update(equipo);
                }
                else
                {
                    equipoRepositorioBD.Add(equipo);
                }
                return RedirectToPage("Index");
            } else { return Page(); }
        }

        private String ProcessUploadedFile(IFormFile Photo)
        {
            string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, Photo.FileName); // así concatenamos toda la ruta entera con el nombre del archivo
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;
        }
    }
}
