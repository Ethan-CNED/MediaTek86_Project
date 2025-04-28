using Kanban.bddmanager;
using System;
using System.Collections.Generic;
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
            string query = "SELECT idPersonnel, dateDebut, dateFin, idmotif FROM absence";
            return BddManager.GetInstance(connectionString).ReqSelect(query);
        }

        /// <summary>
        /// Ajoute une nouvelle absence dans la base de données.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel concerné.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif de l'absence.</param>
        public static void AddAbsence(int idPersonnel, string dateDebut, string dateFin, int idMotif)
        {
            string query = "INSERT INTO absence (idPersonnel, dateDebut, dateFin, idMotif) VALUES (@idPersonnel, @dateDebut, @dateFin, @idMotif)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@idPersonnel", idPersonnel},
                {"@dateDebut", dateDebut},
                {"@dateFin", dateFin},
                {"@idMotif", idMotif}
            };
            BddManager.GetInstance(connectionString).ReqUpdate(query, parameters);
        }

        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel concerné.</param>
        /// <param name="dateDebut">Date de début de l'absence à supprimer.</param>
        public static void DeleteAbsence(int idPersonnel, string dateDebut)
        {
            string query = "DELETE FROM absence WHERE idPersonnel = @idPersonnel AND dateDebut = @dateDebut";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@idPersonnel", idPersonnel},
                {"@dateDebut", dateDebut}
            };
            BddManager.GetInstance(connectionString).ReqUpdate(query, parameters);
        }
    }
}