using System;
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
            string gestPath = path + @"\Gestionnaires.txt";
            string acctPath = path + @"\Comptes.txt";
            string trxnPath = path + @"\Transactions.txt";
            string sttsPath = path + @"\Statut_Transactions.txt";
            string stosPath = path + @"\Statut_Operations.txt";
            string metrPath = path + @"\Metrologie.txt";
            
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
