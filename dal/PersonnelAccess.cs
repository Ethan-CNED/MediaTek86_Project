using Kanban.bddmanager;
using Kanban.model;
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
        public static List<Kanban.model.Personnel> GetAllPersonnels()
        {
            string query = "SELECT idpersonnel, nom, prenom, tel, mail, idservice FROM personnel";
            List<object[]> rows = BddManager.GetInstance().ReqSelect(query);

            List<Kanban.model.Personnel> personnels = new List<Kanban.model.Personnel>();

            foreach (object[] row in rows)
            {
                Kanban.model.Personnel p = new Kanban.model.Personnel
                {
                    idpersonnel = Convert.ToInt32(row[0]),
                    nom = Convert.ToString(row[1]),
                    prenom = Convert.ToString(row[2]),
                    tel = Convert.ToString(row[3]),
                    mail = Convert.ToString(row[4]),
                    idservice = Convert.ToInt32(row[5])
                };

                personnels.Add(p);
            }

            return personnels;
        }

        /// <summary>
        /// Ajoute un Personnel dans la base de donnée.
        /// </summary>
        public static void AddPersonnel(string nom, string prenom, string tel, string mail)
        {
            try
            {
                // Chaîne de connexion à la base de données
                string connectionString = "server=localhost;userid=Mediatek86_Admin;password=GEd(E[*-zmK9w6W7;database=mediatek86_db";

                // Récupérer le dernier idService
                int newIdService;
                string queryGetLastId = "SELECT MAX(idService) FROM personnel";

                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(queryGetLastId, connection))
                    {
                        object result = command.ExecuteScalar();
                        newIdService = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1; // Si aucun ID, commence à 1
                    }
                }

                // Ajouter le nouveau personnel
                string queryInsert = "INSERT INTO personnel (nom, prenom, tel, mail, idService) VALUES (@nom, @prenom, @tel, @mail, @idService)";
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(queryInsert, connection))
                    {
                        // Ajouter les paramètres nécessaires
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@prenom", prenom);
                        command.Parameters.AddWithValue("@tel", tel);
                        command.Parameters.AddWithValue("@mail", mail);
                        command.Parameters.AddWithValue("@idService", newIdService);

                        // Exécuter l'insertion
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'ajout du personnel : {ex.Message}");
            }
        }
    }
}
