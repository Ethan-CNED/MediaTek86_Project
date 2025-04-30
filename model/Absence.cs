using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.model
{
    public class Absence
    {
        public int idPersonnel { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public int idMotif { get; set; }

        // Vous pouvez ajouter une méthode ToString() si besoin pour l'affichage dans un ComboBox, par exemple.
        public override string ToString()
        {
            return $"Personnel: {idPersonnel} | Début: {dateDebut} | Fin: {dateFin} | Motif: {idMotif}";
        }
    }
}
