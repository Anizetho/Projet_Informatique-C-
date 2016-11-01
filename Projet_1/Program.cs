﻿using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_projet
{
    class Program
    {

        // Méthode "lire un fichier" -> on indique le fichier à lire
        static void ReadFile(string file)
        {
            // Lire et afficher les donées du fichier
            try
            {
                // Lis dans le fichier.
                String text = @"C:\Test_create_folder\Sous-Dossier\" + file;

                string line = " ";
                int counter = 0;
                string res = "";

                // Read the file and display it line by line.
                System.IO.StreamReader var = new System.IO.StreamReader(text);

                while ((line = var.ReadLine()) != null)
                {
                    Char sep = ':';
                    String[] split = line.Split(sep);

                    res += "- ";
                    foreach (string value in split)
                    { res += value + " "; }
                    res += "\n";
                    counter++;
                }

                // Ecris ce qui a été lu dans le fichier sur la console.
                Console.WriteLine(res);
                Console.WriteLine("\nVous allez revenir au menu");
            }

            // Erreurs
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }



        }


        // Méthode écrire dans un fichier -> on indique le fichier et ce qu'il faut écrire dans ce fichier
        static void WriteFile(string filetxt, string str)
        {
            string folderName = @"c:\Test_create_folder\";      // Spécifier un nom pour le DOSSIER
            string subfolderName = "Sous-Dossier";              // Spécifier un nom pour le SOUS-DOSSIER
            string pathString = System.IO.Path.Combine(folderName, subfolderName);     // Définit le chemin du DOSSIER au SOUS-DOSSIER.
            System.IO.Directory.CreateDirectory(pathString);                           // Création du chemin du DOSSIER au SOUS-DOSSIER.
            string fileName = filetxt;                                                 // Spécifier un nom pour le fichier
            pathString = System.IO.Path.Combine(pathString, fileName);                 // Définit le chemin du SOUS-DOSSIER au FICHIER.

            // Ajouter du nouveau texte à un fichier existant. 
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathString, true))
            {
                file.WriteLine(str);
            }


        }


        // Méthode trouver la valeur d'un objet -> On indique le fichier et l'élément qu'on recherche dans ce fichier 
        static string[] FindObjectValue(string filetxt, string name)
        {
            string path = @"C:\Test_create_folder\Sous-Dossier\" + filetxt;
            String[] erreur = { "erreur" };

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            // Boucle qui permet de retourner ce que l'on recherche
            while ((line = file.ReadLine()) != null)
            {
                Char sep = ':';
                String[] split = line.Split(sep);

                if (split[1] == name) { return split; }
                counter++;
            }
            return erreur;

        }


        static void Item(string item)
        {
            // On entre les données de création du professeur (nom, prénom, salaire)
            if (item == "Teacher")
            {
                Console.WriteLine("Créer un professeur");
                Console.Write("Prénom : ");
                string firstname = Console.ReadLine();
                Console.Write("Nom : ");
                string lastname = Console.ReadLine();
                Console.Write("Salaire : ");
                int salary = int.Parse(Console.ReadLine());

                // Création de l'objet grâce aux valeurs données.
                Teacher Prof = new Teacher(firstname, lastname, salary);

                //Ecriture dans le fichier 
                string str = Prof.Firstname + ":" + Prof.Lastname + ":" + Prof.Salary + ":" + "\n";
                WriteFile("Teacher.txt", str);

                Console.WriteLine("Le proffesseur a bien été créé dans la base de données.\nVous allez revenir au menu");
                Console.ReadKey();
                return;
            }

            // On définit le nom et prénom d'un étudiant.
            else if (item == "Student")
            {
                Console.WriteLine("Créer un étudiant");
                Console.Write("Prénom : ");
                string firstname = Console.ReadLine();
                Console.Write("Nom : ");
                string lastname = Console.ReadLine();

                // Création de l'objet grâce aux valeurs données.
                Student Etud = new Student(firstname, lastname);

                string str = Etud.Firstname + ":" + Etud.Lastname + ":" + "\n";
                WriteFile("Student.txt", str);

                Console.WriteLine("L'étudiant a bien été créé dans la base de données.\nVous allez revenir au menu");
                Console.ReadKey();
                return;
            }



            // On définit le nombre d'ECTS, le nom, le code et le proffeseur responsable de l'activité
            else if (item == "Activity")
            {
                Console.WriteLine("Créer une activité");
                Console.Write("Nombre ECTS : ");
                int ECTS = int.Parse(Console.ReadLine());
                Console.Write("Nom : ");
                string Name = Console.ReadLine();
                Console.Write("Code : ");
                string Code = Console.ReadLine();
                Console.Write("Attention !! Le nom du professeur doit déjà être encodé ! \n");
                Console.Write("--> Nom du proffesseur : ");
                string teacher = Console.ReadLine();

                //Recréation de l'objet teacher
                String[] data = FindObjectValue("Teacher.txt", teacher);
                Teacher Prof = new Teacher(data[0], data[1], int.Parse(data[2]));

                // Création de l'objet grâce aux valeurs données.
                Activity Cours = new Activity(ECTS, Name, Code, Prof);

                string str = Cours.ECTS + ":" + Cours.Name + ":" + Cours.code + ":" + Prof.Lastname + ":" + "\n";
                // Ecrire les données dans un fichier texte Activity
                WriteFile("Activity.txt", str);

                Console.WriteLine("L'activité a bien été créé dans la base de données.\nVous allez revenir au menu");
                Console.ReadKey();
                return;

            }

            // On définit l'évaluation d'un élève.
            else if (item == "Cote")
            {
                Console.WriteLine("Créer une évaluation");
                Console.WriteLine("");

                // On choisit l'étudiant pour lequel ces notes sont données
                Console.Write("Veuillez indiquer le nom de l'étudiant concerné. \nAttention !! Le nom de l'étudiant doit déjà être encodé ! \n");
                Console.Write("--> Nom de l'étudiant : ");
                string nameOfStudent = Console.ReadLine();
                String[] dataStudent = FindObjectValue("Student.txt", nameOfStudent);
                Student nameStudent = new Student(dataStudent[0], dataStudent[1]);
                Console.WriteLine("L'étudiant a bien été trouvé.");
                Console.WriteLine("");


                // On reprend l'activité dans laquelle on souhaite ajouter une cote ou une appréciation
                Console.Write("Veuillez indiquer le nom de l'activité concernée. \nAttention !! L'activité doit déjà être encodée ! \n");
                Console.Write("--> Nom de l'activité : ");
                string nameActivity = Console.ReadLine();
                //Recréation de l'objet Activity 
                String[] dataActivity = FindObjectValue("Activity.txt", nameActivity);
                //Recréation de l'objet teacher
                string teacher = dataActivity[3];
                String[] dataTeacher = FindObjectValue("Teacher.txt", teacher);
                Teacher Prof = new Teacher(dataTeacher[0], dataTeacher[1], int.Parse(dataTeacher[2]));
                Activity cours = new Activity(int.Parse(dataActivity[0]), dataActivity[1], dataActivity[2], Prof);
                Console.WriteLine("L'activité a bien été trouvée.");
                Console.WriteLine("");


                // On ajoute une cote à cette activité
                Console.Write("Entrez la cote : ");
                int points = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                // Création d'une cote dans une certaine activité -> Rem. : on doit rentrer une "activity"
                Cote cotecours = new Cote(cours);
                cotecours.setNote(points);


                // On ajoute la cote/l'appréciation à la liste des cours
                nameStudent.AddEvaluation(cotecours);

                // On souhaite afficher le nom de l'activité, le nom de l'élève, les points dans cette activité et le nom du prof de cette activité.
                string str = cotecours.Activity.name + ":" +  nameStudent.Lastname + ":" + cotecours.Note() + ":" + cours.teacher.Lastname + ":" + "\n";
                // Ecrire les données dans un fichier texte Activity
                WriteFile("Cote.txt", str);

                Console.WriteLine("La cote a bien été créée dans la base de données.\nVous allez revenir au menu");
                Console.ReadKey();
                return;
            }


            else if (item == "Appréciation")
            {
                Console.WriteLine("Créer une appréciation");
                Console.WriteLine("");

                // On choisit l'étudiant pour lequel ces notes sont données
                Console.Write("Veuillez indiquer le nom de l'étudiant concerné. \nAttention !! Le nom de l'étudiant doit déjà être encodé ! \n");
                Console.Write("--> Nom de l'étudiant : ");
                string nameOfStudent = Console.ReadLine();
                String[] dataStudent = FindObjectValue("Student.txt", nameOfStudent);
                Student nameStudent = new Student(dataStudent[0], dataStudent[1]);
                Console.WriteLine("L'étudiant a bien été trouvée.");
                Console.WriteLine("");


                // On reprend l'activité dans laquelle on souhaite ajouter une cote ou une appréciation
                Console.Write("Attention !! L'activité doit déjà être encodé ! \n");
                Console.Write("--> Nom de l'activité : ");
                string nameActivity = Console.ReadLine();
                //Recréation de l'objet Activity 
                String[] dataActivity = FindObjectValue("Activity.txt", nameActivity);
                //Recréation de l'objet teacher
                string teacher = dataActivity[3];
                String[] dataTeacher = FindObjectValue("Teacher.txt", teacher);
                Teacher Prof = new Teacher(dataTeacher[0], dataTeacher[1], int.Parse(dataTeacher[2]));
                Activity cours = new Activity(int.Parse(dataActivity[0]), dataActivity[1], dataActivity[2], Prof);
                Console.WriteLine("L'activité a bien été trouvée.");
                Console.WriteLine("");


                // On ajoute une appréciation à cette activité
                Console.Write("Entrez l'appréciation : ");
                string appreciation = Console.ReadLine();
                Appreciation apprcours = new Appreciation(cours);
                apprcours.setAppreciation(appreciation);
                Console.WriteLine("");


                // On ajoute l'appréciation à la liste des cours
                nameStudent.AddEvaluation(apprcours);


                // On souhaite afficher le nom de l'activité, le nom de l'élève, les points dans cette activité et le nom du prof de cette activité.
                string str = apprcours.Activity.name + ":" +  nameStudent.Lastname  + ":" + apprcours.Note() + ":" + cours.teacher.Lastname + ":" + "\n";
                // Ecrire les données dans un fichier texte Activity
                WriteFile("Appreciation.txt", str);

                Console.WriteLine("L'appréciation a bien été créée dans la base de données.\nVous allez revenir au menu");
                Console.ReadKey();
                return;
            }



            else if (item == "Bulletin")
            {
                Console.WriteLine("Affichier le Bulletin d'un étudiant");
                Console.WriteLine("");

                // On choisit l'étudiant pour lequel on souhaite voir le bulletin
                // On récupère l'objet Student
                Console.Write("Veuillez indiquer le nom de l'étudiant concerné. \nAttention !! Le nom de l'étudiant doit déjà être encodé ! \n");
                Console.Write("--> Nom de l'étudiant : ");
                string nameOfStudent = Console.ReadLine();
                String[] dataStudent = FindObjectValue("Student.txt", nameOfStudent);
                Student nameStudent = new Student(dataStudent[0], dataStudent[1]);
                Console.WriteLine("L'étudiant a bien été trouvé.");
                Console.WriteLine("");


                // On reprend la liste des activités auxquelles il a participé. 
                Console.Write("Attention !! L'activité doit déjà être encodée ! \n");
                Console.Write("--> Nom de l'activité : ");
                string nameActivity = Console.ReadLine();
                //Recréation de l'objet Activity 
                String[] dataActivity = FindObjectValue("Activity.txt", nameActivity);
                //Recréation de l'objet teacher
                string teacher = dataActivity[3];
                String[] dataTeacher = FindObjectValue("Teacher.txt", teacher);
                Teacher Prof = new Teacher(dataTeacher[0], dataTeacher[1], int.Parse(dataTeacher[2]));
                Activity cours = new Activity(int.Parse(dataActivity[0]), dataActivity[1], dataActivity[2], Prof);
                Console.WriteLine("L'activité a bien été trouvée.");
                Console.WriteLine("");


                // On reprend la cote de cette activité
                String[] dataCote = FindObjectValue("Cote.txt", nameStudent.Lastname);
                int points = int.Parse(dataCote[2]);
                // Création d'une cote dans une certaine activité -> Rem. : on doit rentrer une "activity"
                Cote cotecours = new Cote(cours);
                cotecours.setNote(points);
                Console.WriteLine("La cote pour l'activité '" + cours.name + "' a bien été trouvée. --> " + cotecours.Note());


                // On reprend l'appréciation de cette activité
                String[] dataAppreciation = FindObjectValue("Appreciation.txt", nameStudent.Lastname);
                int appreciation = int.Parse(dataAppreciation[2]);
                string appreciationletter = "";
                for(int i=0 ; i<5 ; i++)
                {
                    if (appreciation == 4) { appreciationletter = "N"; }
                    else if (appreciation == 8) { appreciationletter = "C"; }
                    else if (appreciation == 12) { appreciationletter = "B"; }
                    else if (appreciation == 16) { appreciationletter = "TB"; }
                    else if (appreciation == 20) { appreciationletter = "X"; }
                    else { Console.WriteLine("erreur -> L'Appréciation est introuvable"); }
                }
                Appreciation apprcours = new Appreciation(cours);
                apprcours.setAppreciation(appreciationletter);
                Console.WriteLine("L'appréciation pour l'activité '" + cours.name + "' a bien été trouvée. --> " + apprcours.Note());



                // On ajoute la cote à la liste des cours
                nameStudent.AddEvaluation(cotecours);
                // On ajoute l'appréciation à la liste des cours
                nameStudent.AddEvaluation(apprcours);


                // On crée et on affiche le bulletin 
                Console.WriteLine(" \nEn résumé, voici le buletin de : ");
                nameStudent.Bulletin();


                Console.WriteLine("Voici toutes les infos dont nous disposons actuellement.\nVous allez revenir au menu");
                Console.ReadKey();
                return;
            }



            else { Console.Write("Error"); }
        }

        static void Main()
        {

            //Création d'objet en mode console

            string Accueil =
@"********** Gestion Etablissement **********
1. Gérer et créer des instances 
2. Voir les listes déjà faites
8.Quitter";

            string CreaObjet =
@"********** Création des Objets ********** 
1. Créer Professeur 
2. Créer Etudiant
3. Créer Activité  
4. Créer Cote
5. Créer Appréciation

7. Revenir à l'acceuil
8. Quitter";

            string Listes =
@"********** Création des Objets ********** 
1. Liste des professeurs 
2. Liste des étudiants
3. Liste des activités  
4. Liste des cotes
5. Liste des appréciations
6. Liste des bulletins

7. Revenir à l'acceuil
8. Quitter";

            try
            {
                Console.Clear();
                Console.WriteLine(Accueil);
                int n = (int.Parse(Console.ReadLine()));
                Console.Clear();

                switch (n)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine(Accueil);

                        int var = int.Parse(Console.ReadLine());

                        if (var == 1) { goto case 1; }
                        if (var == 2) { goto case 2; }
                        else { break; }


                    case 1:
                        Console.Clear();
                        Console.WriteLine(CreaObjet);

                        int n2 = (int.Parse(Console.ReadLine()));
                        Console.Clear();


                        switch (n2)
                        {
                            case 1:
                                Item("Teacher");
                                break;
                            case 2:
                                Item("Student");
                                break;
                            case 3:
                                Item("Activity");
                                break;
                            case 4:
                                Item("Cote");
                                break;
                            case 5:
                                Item("Appréciation");
                                break;
                            case 8:
                                break;
                        }
                        goto case 0;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(Listes);

                        int n3 = (int.Parse(Console.ReadLine()));
                        Console.Clear();

                        switch (n3)
                        {
                            case 1:
                                Console.WriteLine("Voici la liste des professeurs : \n");
                                ReadFile("Teacher.txt");
                                Console.ReadKey();
                                break;

                            case 2:
                                Console.WriteLine("Voici la liste des étudiants : \n");
                                ReadFile("Student.txt");
                                Console.ReadKey();
                                break;

                            case 3:
                                Console.WriteLine("Voici la liste des activités : \n");
                                ReadFile("Activity.txt");
                                Console.ReadKey();
                                break;

                            case 4:
                                Console.WriteLine("Voici la liste reprenant dans l'ordre : \n 1) L'activité concernée \n 2) Nom de l'élève \n 3) Les points de l'élève dans cette activité \n 4) Le nom du prof qui gère cette activité \n");
                                ReadFile("Cote.txt");
                                Console.ReadKey();
                                break;

                            case 5:
                                Console.WriteLine("Voici la liste reprenant dans l'ordre : \n 1) L'activité concernée \n 2) Nom de l'élève \n 3) Les points de l'élève dans cette activité \n 4) Le nom du prof qui gère cette activité \n");
                                ReadFile("Appreciation.txt");
                                Console.ReadKey();
                                break;

                            case 6:
                                Item("Bulletin");
                                break;

                            case 7:
                                Console.WriteLine("ok");
                                break;

                            case 8:
                                return;

                        }
                        goto case 0;
                }
            }

            catch (System.FormatException) { Console.WriteLine("Erreur"); }

        }

    }
}

