using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConcentrese
{
    public class Casilla
    {
        public const int OCULTA = 1;
        public const int DESCUBIERTA = 2;
        public const int VISIBLE = 3;
        public const string IMAGEN_OCULTA = "help";

        /// <summary>
        /// El estado actual de la casilla: puede ser OCULTA, DESCUBIERTA O VISIBLE
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Guarda el numero de la casilla, el cual es un indice que indica el orden
        /// de creacion de las casilla.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Guarda el valor de la casilla: el valor representa el contenido de la casilla.
        /// Se usa para verificar si dos casilla son iguales o no. El contenido de la casilla
        /// es representado con numeros y las imagenes estan asociadas a esos numeros.
        /// </summary>
        public int Valor { get; set; }

        public string Imagen;

        public Casilla(int numero, int valor, string imagen)
        {
            Numero = numero;
            Valor = valor;
            Imagen = imagen;
            Estado = OCULTA;
        }

        public void Seleccionar()
        {
            Estado = VISIBLE;
        }

        public void Descubrir()
        {
            Estado = DESCUBIERTA;
        }

        public void Ocultar()
        {
            Estado = OCULTA;
        }

        public bool EsParejaDe(Casilla otraCasilla)
        {
            if (otraCasilla.Valor == Valor)
                return true;
            return false;
        }
    }
}
