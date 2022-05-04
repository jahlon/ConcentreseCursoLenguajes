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
        }

        private void ActualizarListaEncuentros()
        {
            listBoxEncuentros.DataSource = ServidorJuegoConcetrense.Encuentros;
        }

        private void ActualizarListaJugadores()
        {
            
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
