using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    public class Cote : Evaluation
    {
        // Attribut
        private int note;

        // Constructeur
        public Cote(Activity activity) : base(activity)
        {
        }

        // Méthode
        public override int Note()
        {
            return note;
        }

        public void setNote(int note)
        {
            this.note = note;
        }
    }
}

