using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_1
{
    public class Transaction
    {

        public int Numero { get; set; }
        public decimal Montant { get; set; }
        public int NumeroExp { get; set; }
        public int NumeroDest { get; set; }

        public Transaction(int numero, decimal montant, int numeroExp, int numeroDest)
        {
            Numero = numero;
            Montant = montant;
            NumeroExp = numeroExp;
            NumeroDest = numeroDest;
        }

        //public void LectureTransaction(string trxnPath, string sttsPath)
        //{
        //    //Déclaration du dictionnaire
        //    var transactions = new Dictionary<string, List<int>>();

        //    //Lecture du fichier Compte
        //    string[] lines = File.ReadAllLines(trxnPath);

        //    //Séparation des données
        //    foreach (string line in lines)
        //    {
        //        Console.WriteLine($"Fichier : {line}");
        //        string[] split = line.Split(';');
        //        for (int i = 0; i < split.Length; i++)
        //        {
        //            Console.WriteLine($" Infos Split : {split[i]}");
        //        }
        //        string transaction = split[1];

        //        //Classement des données dans le dictionnaire
        //        if (!transactions.ContainsKey(transaction))
        //        {
        //            transactions.Add(transaction, new List<int>());
        //        }
        //    }

        //    //// Ecriture fichier de sortie
        //    //File.WriteAllLines(sttsPath, transactions);
        //}
    }
}
