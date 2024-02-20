using RazorPages.modelos;
namespace RazorPages.service
{
    public interface IAlumnoRepositorio
    {
        IEnumerable<Alumno> GetAllAlumnos();
        Alumno GetAlumno(int id);
        void Update(Alumno alumnoActualizado);
        Alumno Add(Alumno alumnoNuevo);

        Alumno Delete(int id);

        IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso);

        IEnumerable<Alumno> Busqueda(string elementoABuscar);

        IEnumerable<Alumno> Cursos(string curso);
        IEnumerable<Alumno> FindAlumnosByCurso(Curso elementoABuscar);
    }
}