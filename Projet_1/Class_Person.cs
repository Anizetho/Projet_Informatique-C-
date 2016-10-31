using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Test_projet
{
    public class Person
    {
        //Attribut
        private string firstname, lastname;

        //Propriété
        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        //Propriété
        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        //Constructeur 
        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        //Methode
        public void DisplayName()
        {
            //Console.WriteLine("Mon nom est " + lastname + ", " + firstname + ' ' + lastname);
            Console.WriteLine("Nom : " + Lastname + ", Prénom : " + Firstname);
        }

    }
}
