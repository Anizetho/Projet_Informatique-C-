using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test_projet
{
    public class Teacher : Person
    {
        //Attribut
        private int salary;

        //Propriété
        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        //Constructeur 
        public Teacher(string firstname, string lastname, int salary) : base(firstname, lastname)
        {
            Salary = salary;
        }

    }
}
