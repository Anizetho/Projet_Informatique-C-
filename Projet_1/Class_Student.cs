using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    public class Student : Person
    {
        //Attribut 
        //private List<Evaluation> cours;
        public List<Evaluation> cours = new List<Evaluation> { };

        //Propriété
        public List<Evaluation> Cours
        {
            get
            {
                return Cours;
            }

            set
            {
                cours = value;
            }

        }

        //Constructeur 
        public Student(string firstname, string lastname) : base(firstname, lastname)
        {
        }

        //Methode
        public void AddEvaluation(Evaluation evaluation)
        {
            cours.Add(evaluation);
        }

        public double Average()
        {
            double sum = 0;
            for (int i = 0; i < cours.Count(); i++)
            {
                sum += cours[i].Note();
            }

            return sum / cours.Count();
        }

        public void Bulletin()
        {
            string Carnet = "";
            double var = Average();
            for (int i = 0; i < cours.Count(); i++)
            {
                Carnet += cours[i].Activity.Name;
                Carnet += " : ";
                Carnet += cours[i].Note();
                Carnet += "\n";
            }

            Console.WriteLine(Firstname + " " + Lastname + "\n \n" + Carnet + "\n" + "Moyenne : " + Average());
            Console.ReadKey();
        }



    }
}
