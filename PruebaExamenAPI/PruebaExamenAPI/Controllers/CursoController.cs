using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaExamenAPI.Controllers
{
    public class CursoController : ApiController
    {
        public IEnumerable<Cursos> Get()
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Cursos.ToList();
            }
        }
        public Cursos Get(int id)
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Cursos.Find(id);
            }
        }
    }
}
