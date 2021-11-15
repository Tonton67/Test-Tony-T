using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_1
{
    public class Compte
    {

        public int Numero { get; set; }
        public decimal Solde { get; set; }

        public Compte(int numero, decimal solde)
        {
            Numero = numero;
            Solde = solde;
        }

        //public void LectureCompte(string accpPath, string sttsPath)
        //{
        //    //Déclaration du dictionnaire
        //    var comptes = new Dictionary<string, List<int>>();

        //    //Lecture du fichier Compte
        //    string[] lines = File.ReadAllLines(accpPath);

        //    //Séparation des données
        //    foreach (string line in lines)
        //    {
        //        Console.WriteLine($"Fichier : {line}");
        //        string[] split = line.Split(';');
        //        for (int i = 0; i < split.Length; i++)
        //        {
        //            Console.WriteLine($" Infos Split : {split[i]}");
        //        }
        //        string compte = split[1];
                
        //        //Classement des données dans le dictionnaire
        //        if (!comptes.ContainsKey(compte))
        //        {
        //            comptes.Add(compte, new List<int>());
        //        }
        //    }

        //    //// Ecriture fichier de sortie
        //    //File.WriteAllLines(sttsPath, comptes);
        //}
    }
}
