using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnePiece.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Service
{
    public class PirataRepositorioBD : IPirataRepositorioBD
    {
        public OnePieceDbContext context;

        public PirataRepositorioBD(OnePieceDbContext context)
        {
            this.context = context;
        }

        public Pirata GetPirata(int id)
        {
            SqlParameter parametro = new SqlParameter("@Id", id);
            return context.pirata.FromSqlRaw("FindPirataByID {0}", id).ToList().FirstOrDefault();
        }

        public IEnumerable<Pirata> GetPiratas()
        {
            return context.pirata.FromSqlRaw<Pirata>("select * from pirata").ToList();
        }

        public IEnumerable<Pirata> Busqueda(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return context.pirata;
            }
            else
            {
                return context.pirata.Where(a => a.nombre.Contains(elementoABuscar) || a.pais.Contains(elementoABuscar));
            }
        }

        public Pirata Add(Pirata pirataNuevo)
        {
            context.pirata.Add(pirataNuevo);
            context.SaveChanges();
            return pirataNuevo;
        }
    }
}
