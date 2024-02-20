using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.modelos;
using RazorPages.service;

namespace RazorPages1.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;

        [BindProperty]
        public Alumno alumno { get; set; }
        public DeleteModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        public IActionResult OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumno(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            alumnoRepositorio.Delete(alumno.Id);
            return RedirectToPage("Index");
        }
    }
}
