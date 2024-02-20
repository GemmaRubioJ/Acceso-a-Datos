using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaExamenAPI.Controllers
{
    public class AlumnoController : ApiController
    {
        public IEnumerable<Alumnos> Get()
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Alumnos.ToList();
            }
        }
        public Alumnos Get(int id)
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Alumnos.Find(id);
            }
        }
    }
}
