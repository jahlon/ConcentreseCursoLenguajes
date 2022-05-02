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
    class HiloEnviarJugada : HiloBase
    {
        public const int PRIMERA_JUGADA = 1;
        public const int SEGUNDA_JUGADA = 2;


        private readonly Jugador jugador;
        private readonly VentanaPrincipalCliente vista;
        private readonly int jugada;
        private readonly int numeroCasilla;

        public HiloEnviarJugada(Jugador jugador, VentanaPrincipalCliente vista, int jugada, int numeroCasilla)
        {
            this.jugador = jugador;
            this.vista = vista;
            this.jugada = jugada;
            this.numeroCasilla = numeroCasilla;
        }

        protected override void EjecutarHilo()
        {
            if(jugada == PRIMERA_JUGADA)
            {
                jugador.HacerPrimeraJugada(numeroCasilla);
                vista.RefrescarCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
            }
            else
            {
                bool hizoPareja = jugador.HacerSegundaJugada(numeroCasilla);
                vista.RefrescarCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);

                if(hizoPareja)
                {
                    vista.DescubrirCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                    vista.DescubrirCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);

                    if(jugador.TableroJuego.EstaCompleto())
                    {
                        vista.FinalizarJuego();
                    }
                    else
                    {
                        vista.BloquearTablero();
                    }
                }
                else
                {
                    jugador.TableroJuego.EsconderCasillasSeleccionadas();
                    vista.BloquearTablero();
                    Task.Delay(1000).ContinueWith(t =>
                    {
                        vista.DesbloquearCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                        vista.RefrescarCasilla(jugador.TableroJuego.PrimerCasillaSeleccionada);
                        vista.DesbloquearCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);
                        vista.RefrescarCasilla(jugador.TableroJuego.SegundaCasillaSeleccionada);
                    });
                }
                vista.Controlador.EsperarJugada();
            }
        }
    }
}
