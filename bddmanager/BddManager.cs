using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.bddmanager
{
    /// <summary>
    /// Singleton : gestion de la connexion à la base de données et exécution des requêtes SQL.
    /// </summary>
    public class BddManager
    {
        /// <summary>
        /// Instance unique de la classe BddManager.
        /// </summary>
        private static BddManager instance = null;

        /// <summary>
        /// Objet de connexion MySQL.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Constructeur pour créer la connexion à la base de données et l'ouvrir.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base de données.</param>
        private BddManager(string stringConnect)
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        /// <summary>
        /// Obtient ou crée l'unique instance de la classe BddManager.
        /// </summary>
        /// <param name="stringConnect">Chaîne de connexion à la base de données.</param>
        /// <returns>L'instance unique de la classe BddManager.</returns>
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête SQL de type "UPDATE", "INSERT", ou "DELETE".
        /// </summary>
        /// <param name="stringQuery">Requête SQL à exécuter.</param>
        /// <param name="parameters">Paramètres de la requête SQL.</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Exécute une requête SQL de type "SELECT" et retourne une liste de résultats.
        /// </summary>
        /// <param name="stringQuery">Requête SQL à exécuter.</param>
        /// <param name="parameters">Paramètres de la requête SQL.</param>
        /// <returns>Liste des résultats sous forme de tableaux d'objets.</returns>
        public List<object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            List<object[]> records = new List<object[]>();
            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int nbCols = reader.FieldCount;
                while (reader.Read())
                {
                    object[] attributs = new object[nbCols];
                    reader.GetValues(attributs);
                    records.Add(attributs);
                }
            }
            return records;
        }

        /// <summary>
        /// Exécute une requête SQL de type "SELECT" et retourne une valeur unique.
        /// </summary>
        /// <param name="stringQuery">Requête SQL à exécuter.</param>
        /// <param name="parameters">Paramètres de la requête SQL.</param>
        /// <returns>Valeur unique retournée par la requête SQL.</returns>
        public object ReqSelectScalar(string stringQuery, Dictionary<string, object> parameters = null)
        {
            object result = null;
            MySqlCommand command = new MySqlCommand(stringQuery, connection);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }

            command.Prepare();
            result = command.ExecuteScalar();
            return result;
        }
    }
}