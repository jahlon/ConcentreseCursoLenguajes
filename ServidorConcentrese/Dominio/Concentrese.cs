using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    public class Concentrese
    {
        public ICollection<Encuentro> Encuentros;
        public ICollection<EstadisticaJugador> Estadisticas;

        public Concentrese()
        {
            Encuentros = new List<Encuentro>();
            Estadisticas = new List<EstadisticaJugador>();
        }
    }
}
