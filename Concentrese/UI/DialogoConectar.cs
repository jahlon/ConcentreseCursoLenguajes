using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentrese.UI
{
    public partial class DialogoConectar : Form
    {
        private readonly VentanaPrincipalCliente principal;

        public DialogoConectar(VentanaPrincipalCliente principal, string ip, int puerto)
        {
            InitializeComponent();
            textBoxIp.Text = ip;
            textBoxPuerto.Text = puerto.ToString();
            this.principal = principal;
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxJugador.Text;
            string ip = textBoxIp.Text;
            string strPuerto = textBoxPuerto.Text;

            string errorMsg = "Los siguientes errores ocurrieron:";
            bool errorValidacion = false;
            int puerto = 0;

            if(nombre.Length == 0)
            {
                errorMsg += "\n- No se ingreso el nombre del jugador";
                errorValidacion = true;
            }

            if (ip.Length == 0)
            {
                errorMsg += "\n- No se ingreso la direccion IP del servidor";
                errorValidacion = true;
            }

            if (strPuerto.Length == 0)
            {
                errorMsg += "\n- No se ingreso el puerto";
                errorValidacion = true;
            }
            else
            {
                if(!int.TryParse(strPuerto, out puerto))
                {
                    errorMsg += "\n- El puerto debe ser un numero entero";
                    errorValidacion = true;
                }
            }

            if(errorValidacion)
            {
                MessageBox.Show(errorMsg, "Error validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                principal.Controlador.ConectarJugador(ip, puerto, nombre);
                Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
