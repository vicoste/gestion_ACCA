using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_tut_ACCA.Metier
{
    abstract class Evenement
    {
        string titre { get; set; }
        DateTime dateEvent { get; set; }
        string type { get; set; }
        string description { get; set; }
        ObservableCollection<Adherent> participants { get; set; }
    }
}
