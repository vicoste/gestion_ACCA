using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projet_tut_ACCA.Metier
{
    public class Application
    {
        private static SqlConnection instance;

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Fonctionnaire> listFonctionnaires;
        public ObservableCollection<Fonctionnaire> ListFonctionnaires
        {
            get { return listFonctionnaires; }
            set { listFonctionnaires = value; OnPropertyChanged("ListeAdherent"); }
        }

        private PlanChasse planDeChasse;
        public PlanChasse PlanDeChasse
        {
            get { return planDeChasse; }
            set { planDeChasse = value; OnPropertyChanged("PlanDeChasse"); }
        }

        private PosteChasse posteDeChasse;
        public PosteChasse PosteDeChasse
        {
            get { return posteDeChasse; }
            set { posteDeChasse = value; OnPropertyChanged("PosteDeChasse"); }
        }

        private ObservableCollection<Evenement> listEvents;
        public ObservableCollection<Evenement> ListEvents
        {
            get { return listEvents; }
            set { listEvents = value; OnPropertyChanged("ListEvents"); }
        }

        private ObservableCollection<CotisationAdherent> lesCotisations;
        public ObservableCollection<CotisationAdherent> LesCotisations
        {
            get { return lesCotisations; }
            set { lesCotisations = value; OnPropertyChanged("LesCotisations"); }
        }

        public Application()
        {
            listFonctionnaires = Fonctionnaire.demandeInfos();
            posteDeChasse = new PosteChasse();
            planDeChasse = new PlanChasse();
            listEvents = Evenement.recupEvenement(listFonctionnaires, posteDeChasse.Zones);
            LesCotisations = CotisationAdherent.DemanderCotisation(this);
        }

        public static SqlConnection getInstance()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename ="+ dir.Substring(0, dir.Length - 9) + "BDACCA.mdf; Integrated Security = True; Connect Timeout = 30";
            return instance = new SqlConnection(connectionString);
        }

        public Fonctionnaire connexion(string login, string mdp)
        {
            foreach(Fonctionnaire f in listFonctionnaires)
            {
                if(f.Adherent.Login == login && f.Adherent.Mdp == mdp)
                    return f;
            }
            return null;
        }

        public void deconnexion()
        {
            Fonctionnaire.ajouterFonctionnaireBDD(ListFonctionnaires);
            Animal.ajoutAnimalBDD(planDeChasse.LesAnimaux);
            Zone.ajoutZoneBDD(posteDeChasse.Zones);
            CotisationAdherent.AjouterCotisation(LesCotisations);
            Evenement.modifEvenementBDD(listEvents);

            instance.Close();
            instance = null;
        }

        public Adherent getAdherentById(int idAd)
        {
            return ListFonctionnaires.First(f => f.Adherent.IdAdherent == idAd).Adherent;
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
