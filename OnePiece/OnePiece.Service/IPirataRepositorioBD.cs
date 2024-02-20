using OnePiece.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Service
{
    public interface IPirataRepositorioBD
    {
        IEnumerable<Pirata> GetPiratas();
        Pirata GetPirata(int id);

        IEnumerable<Pirata> Busqueda(string elementoABuscar);

        Pirata Add(Pirata pirataNuevo);
    }
}
