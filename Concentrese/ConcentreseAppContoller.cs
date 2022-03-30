using ClienteConcentrese;
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

        public VentanaPrincipalCliente Vista { get; set; }

        public ConcentreseAppContoller()
        {
            Vista = new VentanaPrincipalCliente(this);
            JuegoConcentrese = new Juego();
            Vista.CargarTablero(JuegoConcentrese.TableroJuego);
        }

        public void HacerPrimerMovimiento(int numeroCasilla)
        {
            JuegoConcentrese.HacerPrimeraJugada(numeroCasilla);
            Vista.RefrescarCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
        }

        public void HacerSegundoMovimiento(int numeroCasilla)
        {
            bool hizoPareja = JuegoConcentrese.HacerSegundaJugada(numeroCasilla);
            Casilla segundaCasilla = JuegoConcentrese.TableroJuego.SegundaCasillaSeleccionada;
            Vista.RefrescarCasilla(segundaCasilla);
            if(hizoPareja)
            {
                Vista.DescubrirCasilla(JuegoConcentrese.TableroJuego.PrimerCasillaSeleccionada);
                Vista.DescubrirCasilla(segundaCasilla);
                
                if(JuegoConcentrese.EstaCompletoElTablero())
                {
                    MessageBox.Show("Felicitaciones");
                }
            }
            else
            {
                JuegoConcentrese.TableroJuego.EsconderCasillasSeleccionadas();
                Vista.BloquearTablero();
                Task.Delay(1000).ContinueWith(t =>
                {
                    ActualizarCasillas(segundaCasilla);
                    Vista.DesbloquearTablero();
                });
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
