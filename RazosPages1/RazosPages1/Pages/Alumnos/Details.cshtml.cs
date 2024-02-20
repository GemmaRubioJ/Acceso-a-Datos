using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.modelos;
using RazorPages.service;
using RazorPages.services;

namespace RazorPages1.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public Alumno alumno { get; set; }
        public DetailsModel( IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        public void OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumno(id);  //para llamar a este método hay que instanciar un objeto de la clase IAlumnoRepositorio.
        }
    }
}
