using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            List<Compte> cpt = Actions.LectureCompte(acctPath);
            //Console.WriteLine($"Lecture Compte : {cpt}");
            List<Transaction> trans = Actions.LectureTransaction(trxnPath);
            //Console.WriteLine($"Lecture Transaction : {trans}");

            List<Statut> stt = Actions.TraitementTransaction(trans, cpt);
            //Console.WriteLine($"Traitement : {stt}");

            //Ecriture fichier de sortie
            //StreamWriter sw = new StreamWriter(sttsPath);

            //string stts = string.Join(";", stt.ToList());
                        
            using (StreamWriter sw = new StreamWriter(sttsPath))
            {
                foreach (var statut in stt)
                {
                    sw.WriteLine($"{statut.Numero};{statut.Etat}");
                }
                sw.Close();
            }

            //for (int i = 0; i < stt.Count; i++)
            //{
            //    sw.WriteLine();
            //}
            //sw.Close();

            //File.WriteAllLines(sttsPath, stt);


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
