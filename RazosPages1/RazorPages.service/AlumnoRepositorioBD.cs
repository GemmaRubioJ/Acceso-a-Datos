using Microsoft.EntityFrameworkCore.Metadata;
using RazorPages.modelos;
using RazorPages.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
<<<<<<< HEAD
using System.ComponentModel;
=======
>>>>>>> f73c85e6f29ce48e7232f25e7af01fcd740182d6

namespace RazorPages.services
{
    public class AlumnoRepositorioBD : IAlumnoRepositorio
    {
        private ColegioDBContext context;
<<<<<<< HEAD
        
=======

>>>>>>> f73c85e6f29ce48e7232f25e7af01fcd740182d6
        public AlumnoRepositorioBD(ColegioDBContext context)
        {
            this.context = context;
        }


        public Alumno Add(Alumno alumnoNuevo)
        {
            //context.Alumnos.Add(alumnoNuevo);       Estos métodos actuan sobre la lista que se crea en la RAM  y manipula desde ahií.
            // context.SaveChanges();
            context.Database.ExecuteSqlRaw("insertarAlumno {0}, {1}, {2}, {3}, {4}", 
                                            alumnoNuevo.Nombre, 
                                            alumnoNuevo.Apellido,
                                            alumnoNuevo.Email,
                                            alumnoNuevo.Foto,
                                            alumnoNuevo.CursoId);
            return alumnoNuevo;
        }
        public IEnumerable<Alumno> GetAllAlumnos() 
        {
            return context.Alumnos.FromSqlRaw<Alumno>("select * from alumnos").ToList();  //se puede hacer una consulta directamente desde aqui
        }

        public Alumno GetAlumno(int id)
        {
            SqlParameter parametro = new SqlParameter("@Id", id);
            return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoById {0}", id)
                .ToList()
                .FirstOrDefault();
        }

        public void Update(Alumno alumnoActualizado)
        {
            var alumno = context.Alumnos.Attach(alumnoActualizado); // en vez de poner Alumno alumno = context..... ponemos var porque no devuelve un objeto Alumno sino otra cosa
            //no devuelve ni una lista ni un alumno. otra cosa
            alumno.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //hay que poner esto en vez de context.SaveChanges();

        }

        public Alumno Delete(int id)
        {
            Alumno alumnoBorrar = context.Alumnos.Find(id);
            if (alumnoBorrar != null)
            {
                context.Alumnos.Remove(alumnoBorrar);
                context.SaveChanges();
            }
            return alumnoBorrar;
        }

        public IEnumerable<Alumno> Busqueda(string elementoABuscar)
        {
            if (string.IsNullOrWhiteSpace(elementoABuscar))
            {
                return context.Alumnos;
            }
            else
            {
                return context.Alumnos.Where(a => a.Nombre.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
            }
        }

        public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
        {
            IEnumerable<Alumno> consulta = context.Alumnos;
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
                return context.Alumnos.Where(a => a.CursoId.Equals(curso));
            }
        }

        public IEnumerable<Alumno> FindAlumnosByCurso(Curso elementoABuscar)
        {
            if (elementoABuscar == null)
            {
                return context.Alumnos;
            }
            else
            {
                return context.Alumnos.Where(a => a.CursoId.Equals(elementoABuscar));
            }
        }
    }

}
