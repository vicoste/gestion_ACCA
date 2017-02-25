using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    class PlanChasse
    {
        string denomination { get; set; }
        Bague bague;
        DateTime date { get; set; }
        char sexe { get; set; }
        float poids { get; set; }
        string observation { get; set; }

        public PlanChasse(string denomination, Bague bague, DateTime date, char sexe, float poids, string observation)
        {
            this.denomination = denomination;
            this.bague = bague;
            this.date = date;
            this.sexe = sexe;
            this.poids = poids;
            this.observation = observation;
        }
    }
}
