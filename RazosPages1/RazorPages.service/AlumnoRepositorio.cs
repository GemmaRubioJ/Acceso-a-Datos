using RazorPages.modelos;
using RazorPages.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.services
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        public List<Alumno> listaAlumnos;

        public AlumnoRepositorio() //Método constructor 
        {
            listaAlumnos = new List<Alumno>()
            {
                new Alumno() { Id = 1, Nombre = "Alberto Saz", Email = "saz@salesianos.edu", Foto = "Alberto.jpg", CursoId = Curso.H2 },
                new Alumno() { Id = 2, Nombre = "Jesús Montero", Email = "montero@salesianos.edu", Foto = "Jesus.jpg", CursoId = Curso.H2 },
                new Alumno() { Id = 3, Nombre = "Ismael Bernad", Email = "bernad@salesianos.edu", Foto = "Ismael2.jpg", CursoId = Curso.H1 },
                new Alumno() { Id = 4, Nombre = "Isamel Abed", Email = "abed@salesianos.edu", Foto = "Isma1.jpg", CursoId = Curso.H1 }
            };

        }


        public IEnumerable<Alumno> GetAllAlumnos() // Devuelve IEnumerable de alumnos (la lista de alumnos). Una dirección de memoria en la que se encuentra la lista.
        {
            return listaAlumnos;
            throw new NotImplementedException();
        }

        public Alumno GetAlumno(int id)
        {
            return listaAlumnos.FirstOrDefault(a => a.Id == id ); // a es el alias de listaAlumnos // FisdtOrDefault hace una busqueda de la primera ocurrencia
        }

        public void Update(Alumno alumnoActualizado)
        {
            Alumno alumnoEnMemoria = listaAlumnos.FirstOrDefault(a => a.Id == alumnoActualizado.Id);
            alumnoEnMemoria.Nombre = alumnoActualizado.Nombre;
            alumnoEnMemoria.Email = alumnoActualizado.Email;
            alumnoEnMemoria.CursoId = alumnoActualizado.CursoId;
            alumnoEnMemoria.Foto = alumnoActualizado.Foto;

        }

        public Alumno Add(Alumno alumnoNuevo)
        {
            alumnoNuevo.Id = listaAlumnos.Max(a => a.Id) +1;
            listaAlumnos.Add(alumnoNuevo);
            return alumnoNuevo;
        }

        public Alumno Delete(int id)
        {
            Alumno alumnoBorrar = listaAlumnos.Find(a => a.Id == id);
            if(alumnoBorrar != null)
            {
                listaAlumnos.Remove(alumnoBorrar);
            }
            return alumnoBorrar;
        }

        public IEnumerable<Alumno> Busqueda (string elementoABuscar)
        {
            if (string.IsNullOrWhiteSpace(elementoABuscar))
            {
                return listaAlumnos;
            }
            else
            {
                return listaAlumnos.Where(a => a.Nombre.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
            }
        }

        public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
        {
            IEnumerable<Alumno> consulta = listaAlumnos;
            if (curso.HasValue)
            {
                consulta = consulta.Where(a => a.CursoId == curso).ToList();
            }
            //modo predicado, a es el alias del objeto sobre el que actúa el método
            return consulta.GroupBy(a => a.CursoId)
                .Select(g => new CursoCuantos()//g es por el aGrupamiento
                {//hacemos una consulta Select por cada agrupamiento en la que creamos un objeto CursoCuantos
                    Clase = g.Key.Value,
                    NumAlumnos = g.Count()
                }).ToList();//el resultado lo convertimos en lista
        }

        public IEnumerable<Alumno> Cursos(string curso)
        {
            if (string.IsNullOrEmpty(curso))
            {
                return null;
            }
            else
            {
                return listaAlumnos.Where(a => a.CursoId.Equals(curso));
            }
        }

        public IEnumerable<Alumno> FindAlumnosByCurso(Curso elementoABuscar)
        {
            if (elementoABuscar == null)
            {
                return listaAlumnos;
            }
            else
            {
                return listaAlumnos.Where(a => a.CursoId.Equals(elementoABuscar));
            }

        }
    }
}
