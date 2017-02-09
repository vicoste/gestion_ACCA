using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    class Animal
    {
        string type { get; set; }
        int numBague { get; set; }
        DateTime datePrelevement { get; set; }
        char sexe { get; set; }
        float masse { get; set; }
        string observation { get; set; }

        public Animal(string type, DateTime datePrelevement, char sexe, float masse, string observation)
        {
            this.type = type;
            this.datePreveleme

        }
    }
}
