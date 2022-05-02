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
    class HiloEsperarJugada : HiloBase
    {
        private readonly Jugador jugador;
        private readonly VentanaPrincipalCliente vista;

        public HiloEsperarJugada(Jugador jugador, VentanaPrincipalCliente vista)
        {
            this.jugador = jugador;
            this.vista = vista;
        }

        protected override void EjecutarHilo()
        {
            jugador.EsperarPrimeraJugada();
            vista.RefrescarCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
            
            jugador.EsperarSegundaJugada();
            vista.RefrescarCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);

            bool hizoPareja = jugador.EsperarResultado();

            if (hizoPareja)
            {
                vista.DescubrirCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                vista.DescubrirCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);

                if (jugador.JuegoTerminado)
                {
                    vista.FinalizarJuego();
                }
                else
                {
                    vista.DesbloquearTablero();
                }
            }
            else
            {
                jugador.TableroJuego.EsconderCasillasSeleccionadas();
                Task.Delay(1000).ContinueWith(t =>
                {
                    vista.DesbloquearCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                    vista.RefrescarCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                    vista.DesbloquearCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);
                    vista.RefrescarCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);
                    vista.DesbloquearTablero();
                });
            }
        }
    }
}
