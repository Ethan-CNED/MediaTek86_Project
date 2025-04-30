using Kanban.bddmanager;
using Kanban.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.dal
{
    /// <summary>
    /// Accès aux données de la table "absence".
    /// </summary>
    public static class AbsenceAccess
    {
        /// <summary>
        /// Chaîne de connexion à la base de données.
        /// </summary>
        private static readonly string connectionString = "server=localhost;userid=Mediatek86_Admin;password=GEd(E[*-zmK9w6W7;database=mediatek86_db";

        /// <summary>
        /// Récupère la chaîne de connexion pour les méthodes de cette classe.
        /// </summary>
        /// <returns>La chaîne de connexion à la base de données.</returns>
        public static string GetConnectionString()
        {
            return connectionString;
        }

        /// <summary>
        /// Récupère la liste de toutes les absences enregistrées dans la base de données.
        /// </summary>
        /// <returns>Une liste d'objets contenant les informations des absences.</returns>
        public static List<object[]> GetAllAbsences()
        {
            // Utilisation de backticks pour éviter les conflits et en spécifiant le bon nom de colonne pour la table personnel.
            string query = @"
        SELECT p.nom AS Personnel, a.datedebut, a.datefin, a.idMotif 
        FROM `absence` a 
        INNER JOIN `personnel` p ON a.idPersonnel = p.idPersonnel";

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
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dateDebut))
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
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dateFin))
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


        /// <summary>
        /// Ajoute une nouvelle absence dans la base de données.
        /// </summary>
        /// <param name="idPersonnel">Identifiant de la personne de l'absence.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif de l'absence.</param>
        public static void AddAbsence(int idPersonnel, string dateDebut, string dateFin, int idMotif)
        {
            string query = "INSERT INTO absence (idPersonnel, datedebut, datefin, idMotif) VALUES (@idPersonnel, @datedebut, @datefin, @idMotif)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idPersonnel", idPersonnel },
                {"@dateDebut", dateDebut},
                {"@dateFin", dateFin},
                {"@idMotif", idMotif}
            };

            BddManager.GetInstance().ReqUpdate(query, parameters);
        }

    }
}