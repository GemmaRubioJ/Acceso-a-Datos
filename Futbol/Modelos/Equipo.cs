using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Equipo
    {
        public int Id { get; set; }

        public string nomEquipo { get; set; }
        public string ciudad { get; set; }

        public string estadio { get; set; }

        public string escudo { get; set; }

        public int anoFundacion { get; set; }

        public Categoria? categoria  { get; set;}

    }
}
