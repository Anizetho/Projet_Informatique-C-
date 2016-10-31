using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    public class Appreciation : Evaluation
    {
        // Attribut
        private string appreciation;

        // Constructeur
        public Appreciation(Activity activity) : base(activity)
        {
        }

        public override int Note()
        {
            if (this.appreciation == "N")
                return 4;
            if (this.appreciation == "C")
                return 8;
            if (this.appreciation == "B")
                return 12;
            if (this.appreciation == "TB")
                return 16;
            if (this.appreciation == "X")
                return 20;
            else return -10;
        }

        public void setAppreciation(string appreciation)
        {
            this.appreciation = appreciation;
        }

    }
}