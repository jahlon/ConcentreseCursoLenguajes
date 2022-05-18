using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorConcentrese.Dominio
{
    public class AdministradorResultados
    {
        private SqlConnection conexion;

        public void ConectarABaseDeDatos()
        {
            conexion = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conexion.Open();
        }

        public void DesconectarBaseDeDatos()
        {
            conexion.Close();
        }

        public void InicializarTabla()
        {
            using(SqlCommand cmd = conexion.CreateCommand())
            {
                bool crearTable = false;
                try
                {
                    cmd.CommandText = "SELECT * FROM Resultados WHERE 1=2";
                    using (SqlDataReader reader = cmd.ExecuteReader()) { }
                }
                catch (SqlException)
                {
                    crearTable = true;
                }

                if (crearTable)
                {
                    cmd.CommandText = "CREATE TABLE Resultados (nombre varchar(50), ganados int, perdidos int, PRIMARY KEY(nombre))";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstadisticaJugador ConsultarEstadisticaJugador(string nombre)
        {
            EstadisticaJugador estadistica = null;
            using(SqlCommand cmd = conexion.CreateCommand())
            {
                cmd.CommandText = $"SELECT ganados, perdidos FROM Resultados WHERE nombre='{nombre}'";
                using(SqlDataReader reader = cmd.ExecuteReader()) 
                { 
                    if(reader.Read())
                    {
                        int ganados = reader.GetInt32(0);
                        int perdidos = reader.GetInt32(1);
                        estadistica = new EstadisticaJugador(nombre, ganados, perdidos);
                    }
                    else
                    {
                        reader.Close();
                        cmd.CommandText = $"INSERT INTO Resultados(nombre, ganados, perdidos) VALUES ('{nombre}', 0, 0)";
                        cmd.ExecuteNonQuery();
                        estadistica = new EstadisticaJugador(nombre, 0, 0);
                    }
                }
            }
            return estadistica;
        }

        public List<EstadisticaJugador> ConsultarRegistrosJugadores()
        {
            List<EstadisticaJugador> registros = new List<EstadisticaJugador>();
            using(SqlCommand cmd = conexion.CreateCommand())
            {
                cmd.CommandText = "SELECT nombre, ganados, perdidos FROM Resultados";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        int ganados = reader.GetInt32(1);
                        int perdidos = reader.GetInt32(2);

                        EstadisticaJugador estadistica = new EstadisticaJugador(nombre, ganados, perdidos);
                        registros.Add(estadistica);
                    }
                }
            }
            return registros;
        }

        public void RegistrarVictoria(string nombre)
        {
            using(SqlCommand cmd = conexion.CreateCommand())
            {
                cmd.CommandText = $"UPDATE Resultados SET ganados = ganados + 1 WHERE nombre='{nombre}'";
                cmd.ExecuteNonQuery();
            }
        }

        public void RegistrarDerrota(string nombre)
        {
            using (SqlCommand cmd = conexion.CreateCommand())
            {
                cmd.CommandText = $"UPDATE Resultados SET perdidos = perdidos + 1 WHERE nombre='{nombre}'";
                cmd.ExecuteNonQuery();
            }
        }

    }
}
