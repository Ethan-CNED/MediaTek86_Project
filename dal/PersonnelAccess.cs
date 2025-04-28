using Kanban.bddmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.dal
{
    /// <summary>
    /// Accès aux données de la table "personnel".
    /// </summary>
    public static class PersonnelAccess
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
        /// Récupère la liste de tous les personnels enregistrés dans la base de données.
        /// </summary>
        /// <returns>Une liste d'objets contenant les informations des personnels.</returns>
        public static List<object[]> GetAllPersonnels()
        {
            string query = "SELECT idpersonnel, nom, prenom, tel, mail, idservice FROM personnel";
            return BddManager.GetInstance(connectionString).ReqSelect(query);
        }

        /// <summary>
        /// Ajoute un nouveau personnel dans la base de données.
        /// </summary>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Téléphone du personnel.</param>
        /// <param name="email">Email du personnel.</param>
        /// <param name="idService">Identifiant du service du personnel.</param>
        public static void AddPersonnel(string nom, string prenom, string tel, string email, int idService)
        {
            string query = "INSERT INTO personnel (nom, prenom, tel, email, idService) VALUES (@nom, @prenom, @tel, @email, @idService)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@nom", nom},
                {"@prenom", prenom},
                {"@tel", tel},
                {"@email", email},
                {"@idService", idService}
            };
            BddManager.GetInstance(connectionString).ReqUpdate(query, parameters);
        }

        /// <summary>
        /// Supprime un personnel de la base de données.
        /// </summary>
        /// <param name="id">Identifiant unique du personnel.</param>
        public static void DeletePersonnel(int id)
        {
            string query = "DELETE FROM personnel WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@id", id}
            };
            BddManager.GetInstance(connectionString).ReqUpdate(query, parameters);
        }
    }
}