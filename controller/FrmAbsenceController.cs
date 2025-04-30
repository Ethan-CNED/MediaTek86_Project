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
            string query = "SELECT idPersonnel, dateDebut, dateFin, idMotif FROM absence";
            List<object[]> rows = BddManager.GetInstance().ReqSelect(query);

            List<Absence> absences = new List<Absence>();

            foreach (object[] row in rows)
            {
                Absence a = new Absence
                {
                    idPersonnel = Convert.ToInt32(row[0]),
                    dateDebut = Convert.ToDateTime(row[1]),
                    dateFin = Convert.ToDateTime(row[2]),
                    idMotif = Convert.ToInt32(row[3])
                };

                absences.Add(a);
            }

            return absences;
        }
    }
}

