using ConcentreseComun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    class Encuentro : HiloBase
    {
        public const string JUGADOR = "JUGADOR";
        public const string INFO = "INFO";
        public const string PRIMER_TURNO = "1";
        public const string SEGUNDO_TURNO = "2";
        public const string JUGADA = "JUGADA";
        public const string FALLO = "FALLO";
        public const string PAREJA = "PAREJA";
        public const string FIN_JUEGO = "FIN_JUEGO";
        public const string GANADOR = "GANADOR";
        public const int CANTIDAD_CASILLAS = 30;

        private readonly TcpClient clienteJugador1;
        private readonly TcpClient clienteJugador2;
        // private readonly AdministradorResultados administradorResultados;

        public JugadorRemoto Jugador1 { get; set; }
        public JugadorRemoto Jugador2 { get; set; }
        public bool FinJuego { get; set; }

        public Encuentro(TcpClient cliente1, TcpClient cliente2)
        {
            clienteJugador1 = cliente1;
            clienteJugador2 = cliente2;
            FinJuego = false;
            // TODO: Recibir el objeto AdministradorResultados como parametro e inicializar el atributo
        }

        private void EnviarDatos(TcpClient client, string datos)
        {
            byte[] msg = Encoding.ASCII.GetBytes(datos);
            NetworkStream flujo = client.GetStream();
            flujo.Write(msg, 0, msg.Length);
        }

        private string RecibirDatos(TcpClient client)
        {
            string datos = null;
            NetworkStream flujo = client.GetStream();
            Byte[] bytes = new Byte[1024];
            int i = flujo.Read(bytes, 0, bytes.Length);
            datos = Encoding.ASCII.GetString(bytes, 0, i);
            return datos;
        }

        protected void IniciarEncuentro()
        {
            // Leer la informaicion de los jugadores
            string infoJugador1 = RecibirDatos(clienteJugador1);
            EstadisticaJugador estadisiticaJugador1 = new EstadisticaJugador("pedro", 1, 1);
            // TODO: Consultar estadisticas de jugador
            // TODO: Crear JugadorRemoto

            string infoJugador2 = RecibirDatos(clienteJugador2);
            EstadisticaJugador estadisiticaJugador2 = new EstadisticaJugador("maria", 1, 1);
            // TODO: Consultar estadisticas de jugador
            // TODO: Crear JugadorRemoto

            // Enviar a cada jugador las informacion sobre su registro y el del oponente
            EnviarDatos(clienteJugador1, InfoJugador(estadisiticaJugador1));
            EnviarDatos(clienteJugador1, InfoJugador(estadisiticaJugador2));

            EnviarDatos(clienteJugador2, InfoJugador(estadisiticaJugador2));
            EnviarDatos(clienteJugador2, InfoJugador(estadisiticaJugador1));

            // Enviar numero del tablero a los clientes
            string numerosTablero = GenerarNumerosTablero();
            EnviarDatos(clienteJugador1, numerosTablero);
            EnviarDatos(clienteJugador2, numerosTablero);

            // Enviar a cada jugador el turno
            EnviarDatos(clienteJugador1, PRIMER_TURNO);
            EnviarDatos(clienteJugador2, SEGUNDO_TURNO);

        }

        private string GenerarNumerosTablero()
        {
            List<int> numeros = new List<int>();
            for(int i = 1; i <= CANTIDAD_CASILLAS; i++)
            {
                int numero = (i % (CANTIDAD_CASILLAS / 2)) + 1;
                numeros.Add(numero);
            }
            Random rand = new Random();
            numeros = numeros.OrderBy(a => rand.Next()).ToList();

            return String.Join<int>(",", numeros);
        }

        private string InfoJugador(EstadisticaJugador estadisticas)
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.Append(INFO).Append(":")
                        .Append(estadisticas.Nombre).Append(":")
                        .Append(estadisticas.Ganados).Append(":")
                        .Append(estadisticas.Perdidos);
            return infoBuilder.ToString();
        }

        protected override void EjecutarHilo()
        {
            throw new NotImplementedException();
        }
    }
}
