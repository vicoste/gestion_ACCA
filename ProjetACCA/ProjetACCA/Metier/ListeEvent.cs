using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    public class ListeEvent : ObservableCollection<Evenement>
    {
        public ListeEvent() : base()
        {
            Add(new CarnetBattue("Picnic",new DateTime(2017,10,18),"Une bonne bouffe", "tt", new ObservableCollection<Adherent>() ,"18h","19h"));
            Add(new CarnetBattue("Aprem code", new DateTime(2017,10,12), "Journée de codage", "depression", new ObservableCollection<Adherent>() , "14h", "14h30"));
        }
    }
}