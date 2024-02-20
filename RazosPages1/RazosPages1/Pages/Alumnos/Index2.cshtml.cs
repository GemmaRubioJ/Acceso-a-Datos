using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.modelos;
using RazorPages.service;

namespace RazorPages1.Pages.Alumnos
{
    public class Index2Model : PageModel
    {
 
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public IEnumerable<Alumno> Alumnos;


        public Curso Curso;

        [BindProperty(SupportsGet = true)]  //lo relacionamos con el de la pagina web "elementoAMostrar" ahora lo hacemos sin ello
        public Curso elementoABuscar { get; set; }


        public Index2Model(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
            /*esto es inyección de dependencias:
            * que sin llamar explicitamente a los métodos constructores
            * se creen */
        }


        public void OnGet()
        {
            Alumnos = alumnoRepositorio.FindAlumnosByCurso(elementoABuscar);
        }
    }
}
