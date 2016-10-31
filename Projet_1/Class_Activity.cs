using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    public class Activity
    {
        //Attribut 
        public int ects;
        public string name;
        public string code;
        public Teacher teacher;

        //Propriétés
        public int ECTS
        {
            get
            {
                return ects;
            }

            set
            {
                ects = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Code
        {
            get
            {
                return Code;
            }

            set
            {
                code = value;
            }
        }

        public Teacher Teacher
        {
            get
            {
                return teacher;
            }

            set
            {
                teacher = value;
            }
        }

        //Constructeur 
        public Activity(int ects, string name, string code, Teacher teacher)
        {
            ECTS = ects;
            Name = name;
            Code = code;
            Teacher = teacher;
        }


    }
}
