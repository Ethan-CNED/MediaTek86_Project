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
        public string PersonnelName { get; set; }

        public string MotifName { get; set; }

        public DateTime OriginalDateDebut { get; set; }
        public DateTime OriginalDateFin { get; set; }

        public string DisplayDateDebut => dateDebut.ToString("dd/MM/yyyy HH:mm:ss");
        public string DisplayDateFin => dateFin.ToString("dd/MM/yyyy HH:mm:ss");

        public override string ToString()
        {
            return $"{PersonnelName} – {DisplayDateDebut} à {DisplayDateFin} (Motif : {MotifName})";
        }
    }
}
