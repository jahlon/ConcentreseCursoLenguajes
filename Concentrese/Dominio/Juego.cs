using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConcentrese
{
    public class Juego
    {
        public const int CANTIDAD_CASILLAS = 30;

        public Tablero TableroJuego { get; }

        public int Puntaje { get; set; }

        public Juego()
        {
            List<int> listaNumeros = new List<int>();
            for(int i = 1; i <= CANTIDAD_CASILLAS; i++)
            {
                int numero = (i % (CANTIDAD_CASILLAS / 2)) + 1;
                listaNumeros.Add(numero);
            }
            Random rand = new Random();
            listaNumeros = listaNumeros.OrderBy(a => rand.Next()).ToList();

            TableroJuego = new Tablero(listaNumeros.ToArray());
        }

        public void HacerPrimeraJugada(int numeroCasilla)
        {
            TableroJuego.SeleccionarPrimeraCasilla(numeroCasilla);
        }

        /// <summary>
        /// Destapa la segunda casilla de la jugada
        /// </summary>
        /// <param name="numeroCasilla">El numero de la cailla a destapar</param>
        /// <returns>true si con esta segunda casilla se descubrio una pareja, false en caso contrario</returns>
        public bool HacerSegundaJugada(int numeroCasilla)
        {
            bool hizoPareja = TableroJuego.SeleccionarSegundaCasilla(numeroCasilla);
            if (hizoPareja)
                Puntaje++;
            return hizoPareja;
        }

        public bool EstaCompletoElTablero()
        {
            return TableroJuego.EstaCompleto();
        }
    }
}
