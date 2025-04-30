using Kanban.bddmanager;
using Kanban.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.dal
{
    /// <summary>
    /// Accès aux données des motifs.
    /// </summary>
    public static class MotifAccess
    {
        /// <summary>
        /// Récupère la liste de tous les motifs depuis la base de données.
        /// </summary>
        /// <returns>Liste des motifs avec leurs IDs et noms.</returns>
        public static List<Motif> GetAllMotifs()
        {
            string query = "SELECT idmotif, libelle FROM motif";
            var data = BddManager.GetInstance().ReqSelect(query);

            var motifs = new List<Motif>();
            foreach (var row in data)
            {
                motifs.Add(new Motif
                {
                    IdMotif = (int)row[0], // Colonne idmotif
                    Libelle = (string)row[1] // Colonne libelle
                });
            }
            return motifs;
        }
    }
}
