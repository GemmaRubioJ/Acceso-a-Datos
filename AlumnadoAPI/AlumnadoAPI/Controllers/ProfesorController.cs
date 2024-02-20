using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlumnadoAPI.Controllers
{
    public class ProfesorController : ApiController
    {
        public IEnumerable<Profesores> Get()
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Profesores.ToList();
            }
        }
        public Profesores Get(int id)
        {
            using (AlumnadoEntities colegio = new AlumnadoEntities())
            {
                return colegio.Profesores.Find(id);
            }
        }
    }
}
