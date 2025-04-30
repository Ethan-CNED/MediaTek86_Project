using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.model
{
    public class Personnel
    {
        public int idpersonnel { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public int idservice { get; set; }
        public int Id { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return $"{nom} {prenom}";  // Affiche "Nom Prénom"
        }
    }
}

