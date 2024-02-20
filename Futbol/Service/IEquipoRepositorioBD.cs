using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IEquipoRepositorioBD
    {
        IEnumerable<Equipo> GetEquipos();
        Equipo GetEquipo(int id);

        Equipo Add(Equipo equipo);
        void Update(Equipo equipoActualizado);

        Equipo Delete(int id);
        IEnumerable<CategoriaCuantos> EquiposPorCategoria();

<<<<<<< HEAD
        IEnumerable<Equipo> FindEquiposPorCategoria(Categoria elementoABuscar);

=======
>>>>>>> f73c85e6f29ce48e7232f25e7af01fcd740182d6

        
    }
}
