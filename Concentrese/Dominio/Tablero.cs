using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConcentrese
{
    public class Tablero
    {
        public ICollection<Casilla> Casillas { get; }

        public Casilla PrimerCasillaSeleccionada { get; set; }

        public Casilla SegundaCasillaSeleccionada { get; set; }

        public int ParejasHechas { get; set; }

        public int[] Numeros { get; set; }

        public Tablero(int[] numeros)
        {
            Numeros = numeros;
            Casillas = new List<Casilla>();
            ParejasHechas = 0;
            InicializarTablero();
        }

        private void InicializarTablero()
        {
            int numCasilla = 1;
            for(int i=0; i < Numeros.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("_").Append(Numeros[i]);
                Casilla casilla = new Casilla(numCasilla, Numeros[i], sb.ToString());
                numCasilla++;
                Casillas.Add(casilla);
            }
        }

        public void SeleccionarPrimeraCasilla(int numero)
        {
            PrimerCasillaSeleccionada = EncontrarCasilla(numero);
            PrimerCasillaSeleccionada.Seleccionar();
        }

        public bool SeleccionarSegundaCasilla(int numero)
        {
            SegundaCasillaSeleccionada = EncontrarCasilla(numero);
            SegundaCasillaSeleccionada.Seleccionar();
            return VerificarPareja();
        }

        public void EsconderCasillasSeleccionadas()
        {
            PrimerCasillaSeleccionada.Ocultar();
            SegundaCasillaSeleccionada.Ocultar();
        }

        public bool EstaCompleto()
        {
            return ParejasHechas == (Numeros.Length / 2);
        }

        private bool VerificarPareja()
        {
            if(PrimerCasillaSeleccionada.EsParejaDe(SegundaCasillaSeleccionada))
            {
                PrimerCasillaSeleccionada.Descubrir();
                SegundaCasillaSeleccionada.Descubrir();
                ParejasHechas++;
                return true;
            }
            return false;
        }

        private Casilla EncontrarCasilla(int numero)
        {
            foreach(Casilla casilla in Casillas)
            {
                if (casilla.Numero == numero)
                    return casilla;
            }
            return null;
        }
    }
}
