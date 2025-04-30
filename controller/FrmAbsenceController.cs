using System;
using System.Collections.Generic;
using Kanban.bddmanager;
using Kanban.dal;
using Kanban.model;

namespace Kanban.controller
{
    /// <summary>
    /// Contrôleur pour gérer les opérations liées aux absences.
    /// </summary>
    public static class FrmAbsenceController
    {
        /// <summary>
        /// Récupère la liste de toutes les absences depuis la base de données.
        /// </summary>
        /// <returns>Liste des informations des absences.</returns>
        public static List<Absence> GetAllAbsences()
        {
            try
            {
                // Requête SQL pour récupérer les données des absences
                string query = "SELECT idpersonnel, datedebut, datefin, idmotif FROM absence";
                List<object[]> rows = BddManager.GetInstance().ReqSelect(query);

                List<Absence> absences = new List<Absence>();

                foreach (object[] row in rows)
                {
                    // Utilisez les indices pour accéder aux colonnes
                    Absence absence = new Absence
                    {
                        idPersonnel = Convert.ToInt32(row[0]), // ID du personnel (première colonne)
                        dateDebut = DateTime.TryParse(row[1]?.ToString(), out var debut) ? debut : DateTime.MinValue, // Date de début
                        dateFin = DateTime.TryParse(row[2]?.ToString(), out var fin) ? fin : DateTime.MinValue,       // Date de fin
                        idMotif = Convert.ToInt32(row[3])    // ID du motif (quatrième colonne)
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

