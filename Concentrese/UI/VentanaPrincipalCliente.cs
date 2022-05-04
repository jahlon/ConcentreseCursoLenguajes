using ClienteConcentrese;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Concentrese.UI
{
    public partial class VentanaPrincipalCliente : Form
    {
        /// <summary>
        /// Este delegado representa una referencia a un metodo qeu recibe como parametro
        /// una casilla y no retorna nada. Este delegado se asocia con los metodos RefrescarCasilla
        /// BloquearCasilla y DesbloquearCasilla con el fin de poderlos invocar dentro del hilo
        /// que se crea cuando se hacen visibles dos casilla que no son pareja y se hace una
        /// ejecucion retrasada para dejarlas visibles un tiempo antes de volverlas a tapar. Asi
        /// evitamos generar una excepcion por acceso indebido de un hilo a los controles de la
        /// interfaz grafica.
        /// </summary>
        /// <param name="casilla">El modelo de la casilla a la que se le va a cambiar el estado</param>
        delegate void CambiarEstadoCasillaCallback(Casilla casilla);

        delegate void CambiarEstadoTableroCallback();

        delegate void InicializarTableroCallback(Tablero tablero);

        public ConcentreseAppContoller Controlador { get; set; }
        private List<CasillaGrafica> CasillasGraficas;
        private int Movimientos { get; set; }

        public VentanaPrincipalCliente(ConcentreseAppContoller controlador)
        {
            Controlador = controlador;
            InitializeComponent();            
        }

        public void CargarTablero(Tablero tablero)
        {
            if(tablePanelTablero.InvokeRequired)
            {
                InicializarTableroCallback delegado = new InicializarTableroCallback(CargarTablero);
                this.Invoke(delegado, tablero);
            }
            else
                InicializarTablero(tablero);
        }

        private Image ImagenCasilla(Casilla casilla)
        {
            if(casilla.Estado == Casilla.OCULTA)
                return (Image)Properties.Resources.ResourceManager.GetObject(Casilla.IMAGEN_OCULTA);
            else
                return (Image)Properties.Resources.ResourceManager.GetObject(casilla.Imagen);
        }

        private void InicializarTablero(Tablero tablero)
        {
            CasillasGraficas = new List<CasillaGrafica>();
            foreach(Casilla casilla in tablero.Casillas)
            {
                Image imagen = ImagenCasilla(casilla);
                CasillaGrafica casillaGrafica = new CasillaGrafica(imagen, casilla.Numero);
                CasillasGraficas.Add(casillaGrafica);
                casillaGrafica.Dock = DockStyle.Fill;
                tablePanelTablero.Controls.Add(casillaGrafica);
                casillaGrafica.Click += (object sender, System.EventArgs e) =>
                {
                    Movimientos++;
                    int numeroCasilla = ((CasillaGrafica)sender).Numero;
                    if (Movimientos % 2 == 1)
                        Controlador.HacerPrimerMovimiento(numeroCasilla);
                    else
                        Controlador.HacerSegundoMovimiento(numeroCasilla);
                };
            }
        }

        public void RefrescarCasilla(Casilla casilla)
        {
            var casillaGrafica = CasillasGraficas[casilla.Numero - 1];
            if (casillaGrafica.InvokeRequired)
            {
                CambiarEstadoCasillaCallback delegado = new CambiarEstadoCasillaCallback(RefrescarCasilla);
                Invoke(delegado, casilla);
            }
            else
            {
                casillaGrafica.Imagen = ImagenCasilla(casilla);
                casillaGrafica.Refresh();
            }
        }

        public void BloquearTablero()
        {
            tablePanelTablero.Enabled = false;
        }

        public void DesbloquearTablero()
        {
            if(tablePanelTablero.InvokeRequired)
            {
                CambiarEstadoTableroCallback delegado = new CambiarEstadoTableroCallback(DesbloquearTablero);
                Invoke(delegado);
            }
            else
                tablePanelTablero.Enabled = true;
        }

        public void DesbloquearCasilla(Casilla casilla)
        {
            var casillaGrafica = CasillasGraficas[casilla.Numero - 1];

            // Como este metodo se puede ejecutar en un hilo diferente al que creo la 
            // ventana principal, se debe verificar si la modificaciona de la CasillaGrafica
            // requiere una invocacion para su acceso sea Thread-safe
            if(casillaGrafica.InvokeRequired)
            {
                CambiarEstadoCasillaCallback delegado = new CambiarEstadoCasillaCallback(DesbloquearCasilla);
                Invoke(delegado, casilla);
            }
            else 
            {
                casillaGrafica.Desbloquear();
            }
        }

        public void DescubrirCasilla(Casilla casilla)
        {
            var casillaGrafica = CasillasGraficas[casilla.Numero - 1];
            casillaGrafica.Descubrir();
            casillaGrafica.Refresh();
        }

        public void FinalizarJuego()
        {
            MessageBox.Show("Fin de juego!");
        }

        private void buttonConectarAServidor_Click(object sender, System.EventArgs e)
        {
            DialogoConectar dialogo = new DialogoConectar(this, "localhost", 9999);
            dialogo.ShowDialog(this);
        }
    }
}
