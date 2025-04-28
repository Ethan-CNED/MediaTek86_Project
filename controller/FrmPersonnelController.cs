using Kanban.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.controller
{
    /// <summary>
    /// Contrôleur pour gérer les opérations liées aux personnels.
    /// </summary>
    public static class FrmPersonnelController
    {
        /// <summary>
        /// Récupère la liste de tous les personnels depuis la base de données.
        /// </summary>
        /// <returns>Liste des informations des personnels.</returns>
        public static List<object[]> GetAllPersonnels()
        {
            return PersonnelAccess.GetAllPersonnels();
        }
    }
}
