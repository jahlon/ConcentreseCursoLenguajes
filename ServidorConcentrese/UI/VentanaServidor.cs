using ServidorConcentrese.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ServidorConcentrese
{
    public partial class VentanaServidor : Form
    {
        readonly Thread HiloReceptorConexiones;
        public Concentrese ServidorJuegoConcetrense;

        public VentanaServidor(Concentrese servidorConcentrese)
        {
            ServidorJuegoConcetrense = servidorConcentrese;
            InitializeComponent();
            HiloReceptorConexiones = new Thread(() => ServidorJuegoConcetrense.RecibirConexiones());
            HiloReceptorConexiones.IsBackground = true;
            HiloReceptorConexiones.Start();
        }

        private void ActualizarListaEncuentros()
        {
            listBoxEncuentros.DataSource = ServidorJuegoConcetrense.Encuentros;
        }

        private void ActualizarListaJugadores()
        {
            List<EstadisticaJugador> estadisticas = ServidorJuegoConcetrense.AdministradorResultadosServidor.ConsultarRegistrosJugadores();
            listBoxEstadisticas.DataSource = estadisticas;
        }

        private void buttonRefrescarEncuentros_Click(object sender, EventArgs e)
        {
            ActualizarListaEncuentros();
        }

        private void buttonRefrescarEstadisticas_Click(object sender, EventArgs e)
        {
            ActualizarListaJugadores();
        }
    }
}
