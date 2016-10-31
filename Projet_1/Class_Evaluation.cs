using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    public class Evaluation
    {
        // Propriété
        public Activity Activity { get; private set; }

        //Constructeur
        public Evaluation(Activity activity)
        {
            this.Activity = activity;
        }

        // Méthode que l'on peut modifier
        public virtual int Note()
        {
            return -10;
        }
    }
}




/*using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo2
{
class MainClass
{



    public static void Main(string[] args)
    {
        Teacher Lurkin = new Teacher("Q.", "Lurkin", 2300);
        Teacher Calleweart = new Teacher("A.", "Calleweart", 2100);
        Student Thomas = new Student("Thomas", "Anizet");

        Activity Info = new Activity("Info", "I", 4, Lurkin);
        Cote InfoThomas= new Cote(Info);
        InfoThomas.setNote(12);
        Thomas.addEvaluation(InfoThomas);

        Activity Thermodynamique = new Activity("Thermodynamique", "TH", 7, Calleweart);
        Appreciation ThermodynamiqueThomas = new Appreciation(Thermodynamique);
        ThermodynamiqueThomas.setAppreciation("TB");
        Thomas.addEvaluation(ThermodynamiqueThomas);

        Thomas.Bulletin();
        Console.Read();

    }
}
}
*/


