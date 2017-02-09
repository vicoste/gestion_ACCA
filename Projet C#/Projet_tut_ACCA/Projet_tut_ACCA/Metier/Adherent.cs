using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA
{
    class Adherent
    {
        private string idAdherent { get; set; }
        private string nom { get; set; }
        private string prenom { get; set; }
        private string statut { get; set; }
        private string adresse { get; set; }
        private string tel { get; set; }
        private string mail { get; set; }

        public Adherent(string nom, string prenom, string statut, string adresse, string tel, string mail)
        {
            idAdherent = 
            this.nom = nom;
            this.prenom = prenom;
            this.statut = statut;
            this.adresse = adresse;
            this.tel = tel;
            this.mail = mail;
        }

        public Adherent demandeInfos(string login)
        {

        }

    }
}
