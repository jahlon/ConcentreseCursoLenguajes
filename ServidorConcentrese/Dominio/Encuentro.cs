using ConcentreseComun;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    public class Encuentro : HiloBase
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
        private readonly AdministradorResultados administradorResultados;

        public JugadorRemoto Jugador1 { get; set; }
        public JugadorRemoto Jugador2 { get; set; }
        public bool FinJuego { get; set; }

        public Encuentro(TcpClient cliente1, TcpClient cliente2, AdministradorResultados administrador)
        {
            clienteJugador1 = cliente1;
            clienteJugador2 = cliente2;
            FinJuego = false;
            administradorResultados = administrador;
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

        private EstadisticaJugador ConsultarJugador(string info)
        {
            if(info.StartsWith(JUGADOR))
            {
                string nombre = info.Split(':')[1];
                try
                {
                    return administradorResultados.ConsultarEstadisticaJugador(nombre);
                }
                catch(SqlException ex)
                {
                    throw new Exception($"Hubo un problema leyendo la informacion del jugador {ex.Message}");
                }
            }
            else
            {
                throw new Exception($"El mensaje no tiene el formato esperado");
            }
        }

        protected void IniciarEncuentro()
        {
            // Leer la informaicion de los jugadores
            string infoJugador1 = RecibirDatos(clienteJugador1);
            EstadisticaJugador estadisiticaJugador1 = ConsultarJugador(infoJugador1);
            Jugador1 = new JugadorRemoto(estadisiticaJugador1);

            string infoJugador2 = RecibirDatos(clienteJugador2);
            EstadisticaJugador estadisiticaJugador2 = ConsultarJugador(infoJugador2);
            Jugador2 = new JugadorRemoto(estadisiticaJugador2);

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

        protected void ProcesarJugada(int jugador)
        {
            TcpClient clientJugadorActivo = (jugador == 1) ? clienteJugador1 : clienteJugador2;
            TcpClient clientJugadorInactivo = (jugador == 1) ? clienteJugador2 : clienteJugador1;

            // Leer datos de la primera casilla de la jugada
            string lineaCasilla1 = RecibirDatos(clientJugadorActivo);
            if (lineaCasilla1 != null)
            {
                if (!lineaCasilla1.StartsWith(JUGADA))
                {
                    // TODO: Arrojar una excepcion personalizada ConcrentreseException
                    throw new Exception($"Se esperaba {JUGADA}, pero se recibio {lineaCasilla1}");
                }
                EnviarDatos(clientJugadorInactivo, lineaCasilla1);
            }

            // Leer datos de la segunda casilla de la jugada
            string lineaCasilla2 = RecibirDatos(clientJugadorActivo);
            if (lineaCasilla2 != null)
            {
                if (!lineaCasilla2.StartsWith(JUGADA))
                {
                    // TODO: Arrojar una excepcion personalizada ConcrentreseException
                    throw new Exception($"Se esperaba {JUGADA}, pero se recibio {lineaCasilla2}");
                }
                EnviarDatos(clientJugadorInactivo, lineaCasilla2);
            }

            // Leer el resultado de la jugada
            string lineaResultado = RecibirDatos(clientJugadorActivo);
            if (lineaResultado != null)
            {
                if (!lineaResultado.StartsWith(FALLO) && !lineaResultado.StartsWith(PAREJA))
                {
                    // TODO: Arrojar una excepcion personalizada ConcrentreseException
                    throw new Exception($"Se esperaba {FALLO} o {PAREJA}, pero se recibio {lineaResultado}");
                }

                if (lineaResultado.StartsWith(PAREJA))
                {
                    JugadorRemoto jugadorRemoto = (jugador == 1) ? Jugador1 : Jugador2;
                    jugadorRemoto.PuntosEncuentro += 1;

                    FinJuego = bool.Parse(lineaResultado.Split(':')[3]);
                }
                EnviarDatos(clientJugadorInactivo, lineaResultado);
            }
        }

        protected void TerminarEncuentro(int jugador)
        {
            Console.WriteLine("TERMINANDO ENCUENTRO");
            TcpClient clientJugadorActivo = (jugador == 1) ? clienteJugador1 : clienteJugador2;
            TcpClient clientJugadorInactivo = (jugador == 1) ? clienteJugador2 : clienteJugador1;

            // Leer datos del jugador activo
            string lineaFin = RecibirDatos(clientJugadorActivo);
            if (lineaFin != null)
            {
                if (!lineaFin.StartsWith(FIN_JUEGO))
                {
                    // TODO: Arrojar una excepcion personalizada ConcrentreseException
                    throw new Exception($"Se esperaba {FIN_JUEGO}, pero se recibio {lineaFin}");
                }

                EstadisticaJugador ganador = null;
                EstadisticaJugador perdedor = null;

                Console.WriteLine($"Puntos Jugador {Jugador1.Estadisticas.Nombre}: {Jugador1.PuntosEncuentro}");
                Console.WriteLine($"Puntos Jugador {Jugador2.Estadisticas.Nombre}: {Jugador2.PuntosEncuentro}");

                if (Jugador1.PuntosEncuentro > Jugador2.PuntosEncuentro)
                {
                    ganador = Jugador1.Estadisticas;
                    perdedor = Jugador2.Estadisticas;
                }
                else
                {
                    ganador = Jugador2.Estadisticas;
                    perdedor = Jugador1.Estadisticas;
                }

                administradorResultados.RegistrarVictoria(ganador.Nombre);
                administradorResultados.RegistrarDerrota(perdedor.Nombre);

                string lineaGanador = new StringBuilder().Append(GANADOR).Append(":")
                                        .Append(ganador.Nombre).ToString();
                EnviarDatos(clientJugadorInactivo, lineaGanador);
                EnviarDatos(clientJugadorActivo, lineaGanador);

                clienteJugador1.Close();
                clienteJugador2.Close();
            }
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

        public override string ToString()
        {
            // return $"{Jugador1.Estadisticas.Nombre} vs {Jugador2.Estadisticas.Nombre}";
            return $"Encuentro {DateTime.Now}";
        }

        protected override void EjecutarHilo()
        {
            try
            {
                IniciarEncuentro();

                int jugador = 1;

                while(!FinJuego)
                {
                    ProcesarJugada(jugador);
                    if (FinJuego)
                        TerminarEncuentro(jugador);
                    else
                        jugador = (jugador == 1) ? 2 : 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                FinJuego = true;
                clienteJugador1.Close();
                clienteJugador2.Close();
            }
        }
    }
}
