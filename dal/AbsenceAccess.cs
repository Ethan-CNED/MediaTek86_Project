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
        /// <returns>Une liste d'objets Absence contenant les informations des absences.</returns>
        public static List<Absence> GetAllAbsences()
        {
            List<Absence> absences = new List<Absence>();

            // Requête modifiée pour récupérer l'idPersonnel et le libellé du motif
            string query = @"
        SELECT a.idpersonnel, 
               p.nom AS Personnel, 
               a.datedebut, 
               a.datefin, 
               a.idMotif, 
               m.Libelle AS MotifLibelle
        FROM absence a 
        INNER JOIN personnel p ON a.idPersonnel = p.idPersonnel
        LEFT JOIN motif m ON a.idMotif = m.idMotif";

            var results = BddManager.GetInstance().ReqSelect(query);

            // Formats attendus pour la conversion des dates.
            string[] formats = { "yyyy-MM-dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };

            foreach (var row in results)
            {
                try
                {
                    int idPersonnel = Convert.ToInt32(row[0]);
                    string personnelName = row[1].ToString();

                    DateTime dateDebut = DateTime.MinValue;
                    DateTime dateFin = DateTime.MinValue;

                    if (row[2] != DBNull.Value)
                    {
                        string dateDebutStr = row[2].ToString();
                        if (!DateTime.TryParseExact(dateDebutStr, formats, CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dateDebut))
                        {
                            Console.WriteLine($"Date début invalide : {row[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Date début (DBNull) invalide.");
                    }

                    if (row[3] != DBNull.Value)
                    {
                        string dateFinStr = row[3].ToString();
                        if (!DateTime.TryParseExact(dateFinStr, formats, CultureInfo.InvariantCulture,
                                                      DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dateFin))
                        {
                            Console.WriteLine($"Date fin invalide : {row[3]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Date fin (DBNull) invalide.");
                    }

                    int idMotif = Convert.ToInt32(row[4]);
                    string motifName = row.Length > 5 && row[5] != DBNull.Value ? row[5].ToString() : string.Empty;

                    Absence absence = new Absence
                    {
                        idPersonnel = idPersonnel,
                        PersonnelName = personnelName,
                        dateDebut = dateDebut,
                        dateFin = dateFin,
                        idMotif = idMotif,
                        MotifName = motifName,
                        OriginalDateDebut = dateDebut,
                        OriginalDateFin = dateFin
                    };

                    absences.Add(absence);
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
        public static int AddAbsence(int idPersonnel, string dateDebut, string dateFin, int idMotif)
        {
            string query = "INSERT INTO absence (idPersonnel, datedebut, datefin, idMotif) VALUES (@idPersonnel, @datedebut, @datefin, @idMotif)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idPersonnel", idPersonnel },
                { "@dateDebut", dateDebut },
                { "@dateFin", dateFin },
                { "@idMotif", idMotif }
            };

            int rowsAffected = BddManager.GetInstance().ReqUpdate(query, parameters);
            return rowsAffected;
        }

        /// <summary>
        /// Met à jour une absence dans la base de données, y compris la modification du personnel.
        /// </summary>
        /// <param name="oldIdPersonnel">Ancien identifiant du personnel (pour la clause WHERE).</param>
        /// <param name="newIdPersonnel">Nouveau identifiant du personnel (valeur à mettre dans SET).</param>
        /// <param name="newDateDebut">Nouvelle date de début.</param>
        /// <param name="newDateFin">Nouvelle date de fin.</param>
        /// <param name="idMotif">Nouvel identifiant du motif.</param>
        /// <param name="oldDateDebut">Ancienne date de début.</param>
        /// <param name="oldDateFin">Ancienne date de fin.</param>
        public static int UpdateAbsence(int oldIdPersonnel, int newIdPersonnel, string newDateDebut, string newDateFin, int idMotif, string oldDateDebut, string oldDateFin)
        {
            string query = @"
                UPDATE absence 
                SET idpersonnel = @newIdPersonnel,
                    datedebut = @newDateDebut, 
                    datefin = @newDateFin, 
                    idmotif = @idMotif 
                WHERE idpersonnel = @oldIdPersonnel 
                  AND datedebut = @oldDateDebut 
                  AND datefin = @oldDateFin";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@newIdPersonnel", newIdPersonnel },
                { "@newDateDebut", newDateDebut },
                { "@newDateFin", newDateFin },
                { "@idMotif", idMotif },
                { "@oldIdPersonnel", oldIdPersonnel },
                { "@oldDateDebut", oldDateDebut },
                { "@oldDateFin", oldDateFin }
            };

            int rowsAffected = BddManager.GetInstance().ReqUpdate(query, parameters);
            return rowsAffected;
        }

        public static int DeleteAbsence(Absence absence)
        {
            string query = @"DELETE FROM absence 
                     WHERE idpersonnel = @idPersonnel 
                       AND datedebut = @dateDebut 
                       AND datefin = @dateFin 
                       AND idMotif = @idMotif";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@idPersonnel", absence.idPersonnel },
        { "@dateDebut", absence.dateDebut.ToString("yyyy-MM-dd HH:mm:ss") },
        { "@dateFin", absence.dateFin.ToString("yyyy-MM-dd HH:mm:ss") },
        { "@idMotif", absence.idMotif }
    };

            return BddManager.GetInstance().ReqUpdate(query, parameters);
        }

        public static int DeleteAbsencesByPersonnel(int idPersonnel)
        {
            string query = "DELETE FROM absence WHERE idpersonnel = @idPersonnel";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@idPersonnel", idPersonnel }
    };
            return BddManager.GetInstance().ReqUpdate(query, parameters);
        }


    }
}
