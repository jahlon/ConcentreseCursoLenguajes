using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    public class Concentrese
    {
        private TcpListener servidor;
        private TcpClient clienteEnEspera;
        public ICollection<Encuentro> Encuentros;
        public AdministradorResultados AdministradorResultadosServidor;
        public ICollection<EstadisticaJugador> Estadisticas;

        public Concentrese()
        {
            Encuentros = new List<Encuentro>();
            AdministradorResultadosServidor = new AdministradorResultados();
            AdministradorResultadosServidor.ConectarABaseDeDatos();
            AdministradorResultadosServidor.InicializarTabla();
            Estadisticas = new List<EstadisticaJugador>();
        }

        public void RecibirConexiones()
        {
            try
            {
                int puerto = Properties.Settings.Default.Puerto;
                IPAddress ipLocal = IPAddress.Parse(Properties.Settings.Default.Ip);

                servidor = new TcpListener(ipLocal, puerto);

                servidor.Start();

                while (true)
                {
                    TcpClient nuevoCliente = servidor.AcceptTcpClient();
                    Console.WriteLine($"Conexion recibida {nuevoCliente.Client.RemoteEndPoint}");
                    CrearEncuentro(nuevoCliente);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

        private void CrearEncuentro(TcpClient nuevoCliente)
        {
            if(clienteEnEspera == null)
            {
                clienteEnEspera = nuevoCliente;
            }
            else
            {
                TcpClient jugador1 = clienteEnEspera;
                TcpClient jugador2 = nuevoCliente;

                clienteEnEspera = null;

                Encuentro nuevoEncuentro = new Encuentro(jugador1, jugador2, AdministradorResultadosServidor);
                Encuentros.Add(nuevoEncuentro);
                Console.WriteLine($"Nuevo encuentro creado {nuevoEncuentro}");
                nuevoEncuentro.Start();
            }
        }


    }
}
