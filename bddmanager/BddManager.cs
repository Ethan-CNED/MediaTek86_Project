using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.bddmanager
{
    internal class BddManager
    {
        public static class DatabaseManager
        {
            private const string ConnectionString = "votre_chaine_de_connexion";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(ConnectionString);
            }

            public static void ExecuteQuery(string query)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
