using System.Collections.Generic;
using Kanban.dal;

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
        public static List<object[]> GetAllAbsences()
        {
            return AbsenceAccess.GetAllAbsences();
        }
    }
}

