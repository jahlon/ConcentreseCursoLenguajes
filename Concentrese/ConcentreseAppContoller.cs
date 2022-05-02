using ClienteConcentrese;
using Concentrese.Dominio;
using Concentrese.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentrese
{
    public class ConcentreseAppContoller
    {

        public Juego JuegoConcentrese { get; set; }

        public Jugador JugadorConcentrese { get; set; }

        public VentanaPrincipalCliente Vista { get; set; }

        public ConcentreseAppContoller()
        {
            Vista = new VentanaPrincipalCliente(this);
            // JuegoConcentrese = new Juego();
            // Vista.CargarTablero(JuegoConcentrese.TableroJuego);
        }

        public void ConectarJugador(string host, int puerto, string nombre)
        {
            JugadorConcentrese = new Jugador(host, puerto, nombre);
            HiloConectar hiloConectar = new HiloConectar(JugadorConcentrese, Vista);
            hiloConectar.IsBackground = true;
            hiloConectar.Start();
        }

        public void HacerPrimerMovimiento(int numeroCasilla)
        {
            HiloEnviarJugada hiloEnviarJugada = new HiloEnviarJugada(JugadorConcentrese, Vista,
                                                        HiloEnviarJugada.PRIMERA_JUGADA, numeroCasilla);
            hiloEnviarJugada.IsBackground = true;
            hiloEnviarJugada.Start();
            // JuegoConcentrese.HacerPrimeraJugada(numeroCasilla);
            // Vista.RefrescarCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
        }

        public void HacerSegundoMovimiento(int numeroCasilla)
        {
            HiloEnviarJugada hiloEnviarJugada = new HiloEnviarJugada(JugadorConcentrese, Vista,
                                                       HiloEnviarJugada.SEGUNDA_JUGADA, numeroCasilla);
            hiloEnviarJugada.IsBackground = true;
            hiloEnviarJugada.Start();
            //bool hizoPareja = JuegoConcentrese.HacerSegundaJugada(numeroCasilla);
            //Casilla segundaCasilla = JuegoConcentrese.TableroJuego.SegundaCasillaSeleccionada;
            //Vista.RefrescarCasilla(segundaCasilla);
            //if(hizoPareja)
            //{
            //    Vista.DescubrirCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
            //    Vista.DescubrirCasilla(segundaCasilla);

            //    if(JuegoConcentrese.EstaCompletoElTablero())
            //    {
            //        MessageBox.Show("Felicitaciones");
            //    }
            //}
            //else
            //{
            //    JuegoConcentrese.TableroJuego.EsconderCasillasSeleccionadas();
            //    Vista.BloquearTablero();
            //    Task.Delay(1000).ContinueWith(t =>
            //    {
            //        ActualizarCasillas(segundaCasilla);
            //        Vista.DesbloquearTablero();
            //    });
            //}
        }

        public void EsperarJugada()
        {
            if(JugadorConcentrese.EstadoJuego == Jugador.ESPERANDO_TURNO_OPONENTE)
            {
                Vista.BloquearTablero();
                HiloEsperarJugada hiloEsperarJugada = new HiloEsperarJugada(JugadorConcentrese, Vista);
                hiloEsperarJugada.IsBackground = true;
                hiloEsperarJugada.Start();
            }
        }

        private void ActualizarCasillas(Casilla segundaCasilla)
        {
            Vista.DesbloquearCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
            Vista.RefrescarCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
            Vista.DesbloquearCasilla(segundaCasilla);
            Vista.RefrescarCasilla(segundaCasilla);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConcentreseAppContoller controlador = new ConcentreseAppContoller();
            Application.Run(controlador.Vista);
        }
    }
}
