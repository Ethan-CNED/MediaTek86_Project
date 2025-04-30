using Kanban.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using Kanban.dal;
using Kanban.model;
using System.Windows.Forms;

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

        public int ReqUpdate(string query, Dictionary<string, object> parameters)
        {
            int rowsAffected = 0;
            using (var connection = new MySqlConnection(stringConnect))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> parameter in parameters)
                        {
                            command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                        }
                    }
                    // Exécuter la requête et récupérer le nombre de lignes affectées :
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
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
        /// Récupère la liste des absences en effectuant une jointure pour obtenir le nom du personnel.
        /// </summary>
        /// <returns>List d'objets Absence</returns>
        public static List<Absence> GetAllAbsences()
        {
            try
            {
                MessageBox.Show("Point d'arrêt : avant affichage de query");
                string query = "SELECT mediatek86_db.absence.idpersonnel, mediatek86_db.absence.datedebut, " +
                               "mediatek86_db.absence.datefin, mediatek86_db.absence.idmotif, mediatek86_db.personnel.nom " +
                               "FROM mediatek86_db.absence " +
                               "INNER JOIN mediatek86_db.personnel ON mediatek86_db.absence.idpersonnel = mediatek86_db.personnel.idpersonnel";
                MessageBox.Show(query);



                ;
                List<object[]> rows = BddManager.GetInstance().ReqSelect(query);
                List<Absence> absences = new List<Absence>();

                // Formats attendus pour la conversion des dates
                string[] formats = { "yyyy-MM-dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };

                foreach (var row in rows)
                {
                    DateTime dateDebut = DateTime.MinValue;
                    DateTime dateFin = DateTime.MinValue;

                    // Conversion de la colonne 'datedebut' (index 1)
                    if (row[1] != DBNull.Value)
                    {
                        string dateDebutStr = row[1].ToString();
                        if (!DateTime.TryParseExact(
                                dateDebutStr,
                                formats,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal,
                                out dateDebut))
                        {
                            Console.WriteLine($"Date début invalide : {row[1]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Date début invalide (null)");
                    }

                    // Conversion de la colonne 'datefin' (index 2)
                    if (row[2] != DBNull.Value)
                    {
                        string dateFinStr = row[2].ToString();
                        if (!DateTime.TryParseExact(
                                dateFinStr,
                                formats,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal,
                                out dateFin))
                        {
                            Console.WriteLine($"Date fin invalide : {row[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Date fin invalide (null)");
                    }

                    // Création d'un objet Absence
                    Absence absence = new Absence
                    {
                        PersonnelName = row[0]?.ToString(),
                        dateDebut = dateDebut,
                        dateFin = dateFin,
                        idMotif = Convert.ToInt32(row[3]),
                        // Stockage des valeurs d'origine pour servir de clé composite lors de l'update
                        OriginalDateDebut = dateDebut,
                        OriginalDateFin = dateFin
                    };

                    absences.Add(absence);
                }

                return absences;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des absences : {ex.Message}");
                return new List<Absence>(); // Retourne une liste vide en cas d'erreur
            }
        }
    }
}
