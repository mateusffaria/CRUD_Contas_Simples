using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.util
{
    class ConectaDB
    {
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string username = "postgres";
        private static string password = "123Fatec";
        private static string dataBaseName = "dbfluxo";

        public static NpgsqlConnection getConexao()
        {
            try
            {
                string stgConexao = String.Format("Server = {0}; Port= {1}; User Id={2}; Password={3}; Database={4}",
                    serverName, port, username, password, dataBaseName);
                NpgsqlConnection npgsqlConnection = new NpgsqlConnection(stgConexao);

                npgsqlConnection.Open();

                return npgsqlConnection;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
