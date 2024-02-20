using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.modelos;
using RazorPages.service;

namespace RazorPages1.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorioBD; //objeto de la clase alumnoRepositorio para llamar al metodo GetAllAlumnos() que está en esta clase
        public IEnumerable<Alumno> Alumnos;
        public List<Alumno> listaAlumnos { get; set; }
        public string elementoABuscar { get; set; }
        public IndexModel(IAlumnoRepositorio alumnoRepositorio) //inyección de dependencias
        {
            this.alumnoRepositorioBD = alumnoRepositorio;
        }
        public void OnGet(string elementoABuscar = "")
        {
            Alumnos = alumnoRepositorioBD.Busqueda(elementoABuscar);
        }
    }
}
