using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentrese.UI
{
    public partial class CasillaGrafica : UserControl
    {
        public int Numero { get; set; }
        public Image Imagen { get; set; }
        public Color ColorFondo { get; set; }
        private bool Descubierta { get; set; }

        public CasillaGrafica(Image imagen, int numero)
        {
            Numero = numero;
            Imagen = imagen;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void Bloquear()
        {
            Enabled = false;
        }

        public void Desbloquear()
        {
            Enabled = true;
        }

        public void Descubrir()
        {
            Enabled = false;
            Descubierta = true;
            ColorFondo = Color.LightGreen;
        }

        private void CasillaGrafica_Paint(object sender, PaintEventArgs e)
        {
            if (Descubierta)
                e.Graphics.FillRectangle(new SolidBrush(ColorFondo), ClientRectangle);
            else
                e.Graphics.FillRectangle(new SolidBrush(DefaultBackColor), ClientRectangle);

            Rectangle rect = this.ClientRectangle;
            int imgX = (rect.Width - Imagen.Width) / 2;
            int imgY = (rect.Height - Imagen.Height) / 2;
            Rectangle imagenRect = new Rectangle(imgX, imgY, Imagen.Width, Imagen.Height);
            e.Graphics.DrawImageUnscaledAndClipped(Imagen, imagenRect);
        }
    }
}
