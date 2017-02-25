using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Projet_tut_ACCA.Metier
{
    public class Adherent
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int idAdherent;
        public int IdAdherent {
            get { return idAdherent; }
            set { idAdherent = value; OnPropertyChanged("IdAdherent"); }
        }

        private string login;
        public string Login{
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }

        private string mdp;
        public string Mdp{
            get { return mdp; }
            set { mdp = value; OnPropertyChanged("Mdp"); }
        }

        private string nom;
        public string Nom {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }

        private string prenom;
        public string Prenom {
            get { return prenom; }
            set { prenom = value; OnPropertyChanged("Prenom"); }
        }

        private String statut; 
        public String Statut {
            get { return statut; }
            set { statut = value; OnPropertyChanged("Statut"); }
        }

        private string adresse;
        public string Adresse{
            get { return adresse; }
            set { adresse = value; OnPropertyChanged("Adresse"); }
        }

        private string tel;
        public string Tel{
            get { return tel; }
            set { tel = value; OnPropertyChanged("Tel"); }
        }

        private string mail;
        public string Mail{
            get { return mail; }
            set { mail = value; OnPropertyChanged("Mail"); }
        }

        public Adherent(int idAdherent, string login, string mdp, string nom, string prenom, String statut, string adresse, string tel, string mail)
        {
            this.idAdherent = idAdherent;
            this.login = login;
            this.mdp = mdp;
            this.nom = nom;
            this.prenom = prenom;
            this.statut = statut;
            this.adresse = adresse;
            this.tel = tel;
            this.mail = mail;
        }

        public Adherent()
        {
            idAdherent = 0;
        }

        public Boolean participerEvenement(Evenement evenement)
        {
            if (evenement.Participants.Contains(this))
            {
                return false;
            }
            else
            {
                evenement.Participants.Add(this);
                return true;
            }
        }

        public Boolean quitterEvenement(Evenement evenement)
        {
            if (!evenement.Participants.Contains(this))
            {
                return false; 
            }
            else
            {
                evenement.Participants.Remove(this);
                return true;
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }


    }
}
