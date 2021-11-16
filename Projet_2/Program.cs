﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string gestPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_Transactions_1.txt";
            string stosPath = path + @"\Statut_Operations_1.txt";
            string metrPath = path + @"\Metrologie_1.txt";

            List<Gestionnaire> gest = Actions.LectureGestionnaire(gestPath);

            List<Compte> cpt = Actions.LectureCompte(acctPath);

            List<Transaction> trans = Actions.LectureTransaction(trxnPath);


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
