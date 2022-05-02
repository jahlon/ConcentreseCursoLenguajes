using ClienteConcentrese;
using Concentrese.UI;
using ConcentreseComun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentrese.Dominio
{
    class HiloConectar : HiloBase
    {
        private readonly Jugador jugador;
        private readonly VentanaPrincipalCliente vista;

        public HiloConectar(Jugador jugador, VentanaPrincipalCliente vista)
        {
            this.jugador = jugador;
            this.vista = vista;
        }

        protected override void EjecutarHilo()
        {
            jugador.Conectar();
            vista.CargarTablero(jugador.TableroJuego);

            if (jugador.EstadoJuego == Jugador.ESPERANDO_TURNO_OPONENTE)
                vista.Controlador.EsperarJugada();
        }
    }
}
