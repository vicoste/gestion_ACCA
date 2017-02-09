using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA
{
    class Cotisation
    {
        Adherent payeur;
        float paiement { get; set; }
        DateTime datePaiement { get; set; }
        string type { get; set; }

        public Cotisation(Adherent payeur, float paiement, DateTime datePaiement, string type)
        {
            this.payeur = payeur;
            this.paiement = paiement;
            this.datePaiement = datePaiement;
            this.type = type;
        }

        public Cotisation demandeInfos()
        {

        }
    }
}
