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

        public string Nombre { get; set; }
        public string Host { get; set; }
        public int Puerto { get; set; }

        public int EstadoJuego { get; set; }

        private TcpClient cliente;
        private NetworkStream flujo;
        public Tablero TableroJuego;

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
