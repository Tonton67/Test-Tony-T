﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_1
{
    public static class Actions
    {
        public static List<Compte> LectureCompte(string accpPath)
        {
            //Déclaration de la liste
            List<Compte> comptes = new List<Compte>();
            Compte c = new Compte(0, 0);
            int convers;

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(accpPath);

            //Séparation des données
            foreach (string line in lines)
            {

                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');
                for (int i = 0; i < split.Length; i++)
                {
                    Console.WriteLine($" Infos Split C : {split[i]}");
                    int.TryParse(split[0], out convers);
                    c.Numero = convers;

                    if (string.IsNullOrEmpty(split[1]))
                    {
                        c.Solde = 0;
                    }
                    else
                    {
                        c.Solde = System.Convert.ToDecimal(split[1]);
                    }
                }
                comptes.Add(c);
            }
            return comptes;
        }


        public static List<Transaction> LectureTransaction(string trxnPath)
        {
            //Déclaration de la liste
            List<Transaction> transactions = new List<Transaction>();
            Transaction t = new Transaction(0, 0, 0, 0);
            int convers;

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(trxnPath);

            //Séparation des données
            foreach (string line in lines)
            {
                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');
                for (int i = 0; i < split.Length; i++)
                {
                    Console.WriteLine($" Infos Split T : {split[i]}");
                    int.TryParse(split[0], out convers);
                    t.Numero = convers;

                    if (string.IsNullOrEmpty(split[1]))
                    {
                        t.Montant = 0;
                    }
                    else
                    {
                        t.Montant = System.Convert.ToDecimal(split[1]);
                    }

                    int.TryParse(split[0], out convers);
                    t.NumeroExp = convers;
                    int.TryParse(split[0], out convers);
                    t.NumeroDest = convers;
                }
                transactions.Add(t);
            }
            return transactions;
        }

    }
}
