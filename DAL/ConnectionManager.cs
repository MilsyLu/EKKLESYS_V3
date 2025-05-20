using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DAL
{
    public class ConnectionManager
    {
        private readonly string connectionString;

        public ConnectionManager()
        {
            // Obtiene la cadena de App.config
            connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
        }

        public OracleConnection GetConnection()
        {
            // Crear una nueva conexión cada vez
            return new OracleConnection(connectionString);
        }
    }
}