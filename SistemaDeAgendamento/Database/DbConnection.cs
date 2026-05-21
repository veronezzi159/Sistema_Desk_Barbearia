using Npgsql;
using System.Configuration;
using System.Data;

namespace SistemaDeAgendamento.Database
{
    public static class DbConnection
    {
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["BarbershopDb"].ConnectionString;

        public static IDbConnection Create() => new NpgsqlConnection(ConnectionString);
    }
}
