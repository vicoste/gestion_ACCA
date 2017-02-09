using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    class Fonctionnaire
    {
        Adherent adherent;
        Fonction fonction;
        DateTime dateDebut { get; set; }
        DateTime dateFin { get; set; }

        public Fonctionnaire(Adherent adherent, Fonction fonction, DateTime dateDebut)
        {
            this.adherent = adherent;
            this.fonction = fonction;
            this.dateDebut = dateDebut;
        }
    }
}
