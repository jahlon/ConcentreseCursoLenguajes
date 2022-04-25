using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    class JugadorRemoto
    {
        public int PuntosEncuentro { get; set; }

        public EstadisticaJugador Estadisticas { get; set; }

        public JugadorRemoto(EstadisticaJugador estadisticas)
        {
            Estadisticas = estadisticas;
            PuntosEncuentro = 0;
        }
    }
}
