using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Kanban.bddmanager
{
    public class BddManager
    {
        private static BddManager instance = null;

        private static readonly string stringConnect = "server=localhost;userid=Mediatek86_Admin;password=GEd(E[*-zmK9w6W7;database=mediatek86_db;Allow Zero Datetime=True;Convert Zero Datetime=True;";

        private readonly MySqlConnection connection;

        private BddManager()
        {
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            using (MySqlCommand command = new MySqlCommand(stringQuery, connection))
            {
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
        }

        public List<object[]> ReqSelect(string query)
        {
            var results = new List<object[]>();

            // Création d'une connexion locale pour la requête SELECT
            using (var conn = new MySqlConnection(stringConnect))
            {
                conn.Open();
                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            results.Add(row);
                        }
                    }
                }
            }

            return results;
        }

        public object ReqSelectScalar(string stringQuery, Dictionary<string, object> parameters = null)
        {
            using (MySqlCommand command = new MySqlCommand(stringQuery, connection))
            {
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                    }
                }
                command.Prepare();
                object result = command.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        /// Méthode modifiée pour récupérer le nom du personnel via une jointure.
        /// </summary>
        /// <returns>Liste des absences sous forme de tableaux d'objets.</returns>
        public static List<object[]> GetAllAbsences()
        {
            // Remarquez l'utilisation de backticks pour encapsuler les noms de tables/colonnes.
            string query = @"
                SELECT p.nom AS Personnel, a.datedebut, a.datefin, a.idMotif 
                FROM `absence` a 
                INNER JOIN `personnel` p ON a.idPersonnel = p.id";

            var results = BddManager.GetInstance().ReqSelect(query);
            var absences = new List<object[]>();

            // Formats attendus pour la conversion des dates.
            string[] formats = { "yyyy-MM-dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };

            foreach (var row in results)
            {
                try
                {
                    DateTime dateDebut = DateTime.MinValue;
                    DateTime dateFin = DateTime.MinValue;

                    if (row[1] != DBNull.Value)
                    {
                        string dateDebutStr = row[1].ToString();
                        if (!DateTime.TryParseExact(dateDebutStr, formats, CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal,
                                                      out dateDebut))
                        {
                            Console.WriteLine($"Date début invalide : {row[1]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Date début invalide : {row[1]}");
                    }

                    if (row[2] != DBNull.Value)
                    {
                        string dateFinStr = row[2].ToString();
                        if (!DateTime.TryParseExact(dateFinStr, formats, CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal,
                                                      out dateFin))
                        {
                            Console.WriteLine($"Date fin invalide : {row[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Date fin invalide : {row[2]}");
                    }

                    // Ici, row[0] contient désormais le nom du personnel.
                    absences.Add(new object[] { row[0], dateDebut, dateFin, row[3] });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur inattendue lors du traitement des dates : {ex.Message}");
                }
            }

            return absences;
        }
    }
}
