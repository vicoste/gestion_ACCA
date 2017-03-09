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

        public Application()
        {
            //instance = getInstance();

            listFonctionnaires = new ObservableCollection<Fonctionnaire>();
            listFonctionnaires = Fonctionnaire.demandeInfos();

            listEvents = new ObservableCollection<Evenement>();
            listEvents = Evenement.recupEvenement();

            posteDeChasse = new PosteChasse();

            planDeChasse = new PlanChasse();
        }

        public static SqlConnection getInstance()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjetACCA.Properties.Settings.BDACCAConnectionString"].ConnectionString;
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
            instance.Close();
            instance = null;
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
