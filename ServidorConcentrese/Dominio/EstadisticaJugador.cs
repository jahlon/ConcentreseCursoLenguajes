using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    class EstadisticaJugador
    {
        public string Nombre { get; set; }
        public int Ganados { get; set; }
        public int Perdidos { get; set; }
        public double Efectivadad
        {
            get
            {
                if (Ganados + Perdidos > 0)
                {
                    return Ganados * 100d / (Ganados + Perdidos);
                }
                else
                    return 0d;
            }
        }

        public EstadisticaJugador(string nombre, int ganados, int perdidos)
        {
            Nombre = nombre;
            Ganados = ganados;
            Perdidos = perdidos;
        }
    }
}
