using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConcentrese
{
    class Jugador
    {
        public const int SIN_CONECTAR = 0;
        public const int EN_TURNO = 1;
        public const int ESPERANDO_TURNO_OPONENTE = 3;
        public const string JUGADOR = "JUGADOR";
        public const string INFO = "INFO";
        public const string PRIMER_TURNO = "1";
        public const string SEGUNDO_TURNO = "2";
        public const string JUGADA = "JUGADA";
        public const string FALLO = "FALLO";
        public const string PAREJA = "PAREJA";
        public const string FIN_JUEGO = "FIN_JUEGO";
        public const string GANADOR = "GANADOR";

        public string Nombre { get; set; }
        public string Host { get; set; }
        public int Puerto { get; set; }

        public int EstadoJuego { get; set; }

        private TcpClient cliente;
        private NetworkStream flujo;
        public Tablero TableroJuego;

        public bool JuegoTerminado { get; set; }

        public Jugador(string host, int puerto, string nombre)
        {
            Nombre = nombre;
            Host = host;
            Puerto = puerto;
            cliente = new TcpClient();
        }

        public void Conectar()
        {
            try
            {
                cliente.Connect(Host, Puerto);
                flujo = cliente.GetStream();
                IniciarEncuentro();
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void IniciarEncuentro()
        {
            string lineaJugador = new StringBuilder().Append(JUGADOR)
                                                    .Append(":")
                                                    .Append(Nombre)
                                                    .ToString();
            EnviarDatos(lineaJugador);

            string datosJugador1 = RecibirDatos();
            string datosJugador2 = RecibirDatos();

            string numerosTablero = RecibirDatos();
            InicializarTablero(numerosTablero);

            string turno = RecibirDatos();
            if (turno.Equals("1"))
                EstadoJuego = EN_TURNO;
            else
                EstadoJuego = ESPERANDO_TURNO_OPONENTE;
        }

        public void EsperarPrimeraJugada()
        {
            string lineaJugada = RecibirDatos();
            int numeroCasilla1 = int.Parse(lineaJugada.Split(':')[1]);
            TableroJuego.SeleccionarPrimeraCasilla(numeroCasilla1);
            // TODO: Mostrar informacion en la UI
        }

        public void EsperarSegundaJugada()
        {
            string lineaJugada = RecibirDatos();
            int numeroCasilla1 = int.Parse(lineaJugada.Split(':')[1]);
            TableroJuego.SeleccionarSegundaCasilla(numeroCasilla1);
            // TODO: Mostrar informacion en la UI
        }

        public bool EsperarResultado()
        {
            EstadoJuego = EN_TURNO;

            string resultado = RecibirDatos();
            if(resultado.StartsWith(FALLO))
            {
                // TODO: Mostrar mensaje en el area de informacion
            }
            else if(resultado.StartsWith(PAREJA))
            {
                string[] datosResultado = resultado.Split(':');
                JuegoTerminado = bool.Parse(datosResultado[3]);
                // TODO: Mostrar mensaje en el area de informacion
                return true;
            }

            return false;
        }

        public void HacerPrimeraJugada(int numeroCasilla)
        {
            TableroJuego.SeleccionarPrimeraCasilla(numeroCasilla);
            string jugada = new StringBuilder().Append(JUGADA).Append(":").Append(numeroCasilla).ToString();
            EnviarDatos(jugada);
        }

        public bool HacerSegundaJugada(int numeroCasilla)
        {
            bool hizoPareja = TableroJuego.SeleccionarSegundaCasilla(numeroCasilla);
            string jugada = new StringBuilder().Append(JUGADA).Append(":").Append(numeroCasilla).ToString();
            EnviarDatos(jugada);

            string resultado = FALLO;

            if(hizoPareja)
            {
                int casilla1 = TableroJuego.PrimerCasillaSeleccionada.Numero;
                resultado = new StringBuilder().Append(PAREJA)
                                .Append(":").Append(casilla1)
                                .Append(":").Append(numeroCasilla)
                                .Append(":").Append(TableroJuego.EstaCompleto())
                                .ToString();
            }
            EnviarDatos(resultado);

            EstadoJuego = ESPERANDO_TURNO_OPONENTE;

            return hizoPareja;
        }
        private void InicializarTablero(string numerosTablero)
        {
            //string[] strNumeros = numeroTablero.Split(',');
            //int[] numeros = new int[strNumeros.Length];
            //for(int i = 0; i < numeros.Length; i++)
            //{
            //    numeros[i] = int.Parse(strNumeros[i]);
            //}
            int[] numeros = Array.ConvertAll(numerosTablero.Split(','), s => int.Parse(s));
            TableroJuego = new Tablero(numeros);
        }

        private void EnviarDatos(string datos)
        {
            byte[] msg = Encoding.ASCII.GetBytes(datos);
            flujo.Write(msg, 0, msg.Length);
        }

        private string RecibirDatos()
        {
            string datos = null;
            Byte[] bytes = new Byte[1024];
            int i = flujo.Read(bytes, 0, bytes.Length);
            datos = Encoding.ASCII.GetString(bytes, 0, i);
            return datos;
        }
        
    }
}
