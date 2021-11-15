using System;
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
            int convers;

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(accpPath);

            //Séparation des données
            foreach (string line in lines)
            {

                Compte c = new Compte(0, 0);
                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');
                //Affichage console
                for (int i = 0; i < split.Length; i++)
                {
                    Console.WriteLine($" Infos Split C{i} : {split[i]}");
                }

                c.Numero = int.Parse(split[0]);
                //Cas où le solde est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[1]))
                {
                    c.Solde = 0;
                }
                else
                {
                    c.Solde = decimal.Parse(split[1].Replace(".", ","));
                }
                //Ajout des données dans la liste Compte
                comptes.Add(c);
            }
            return comptes;
        }

        public static List<Transaction> LectureTransaction(string trxnPath)
        {
            //Déclaration de la liste
            List<Transaction> transactions = new List<Transaction>();
            int convers;

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(trxnPath);

            //Séparation des données
            foreach (string line in lines)
            {
                Transaction t = new Transaction(0, 0, 0, 0);
                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');
                //Affichage console
                for (int i = 0; i < split.Length; i++)
                {
                    Console.WriteLine($" Infos Split T{i} : {split[i]}");
                }

                t.Numero = int.Parse(split[0]);
                //Cas où le montant est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[1]))
                {
                    t.Montant = 0;
                }
                else
                {
                    t.Montant = decimal.Parse(split[1].Replace(".", ","));
                }
                t.NumeroExp = int.Parse(split[2]);
                t.NumeroDest = int.Parse(split[3]);
                //Ajout des données dans la liste Transaction
                transactions.Add(t);
            }
            return transactions;
        }

        public static List<Statut> TraitementTransaction(List<Transaction> transactions, List<Compte> comptes)
        {
            List<Statut> statuts = new List<Statut>();


            foreach (var trans in transactions)
            {
                Statut statut = new Statut(trans.Numero, "KO");
                //Compte cexp = comptes.Find(cpt => trans.NumeroExp == cpt.Numero);
                Compte cExp;
                //Compte cdest = comptes.Find(cpt => trans.NumeroDest == cpt.Numero);
                Compte cDest;
                //SI Dépôt
                if (trans.NumeroExp == 0 && trans.NumeroDest != 0)
                {
                    cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                    if (cDest != null)
                    {
                        if (trans.Montant >= 0)
                        {
                            cDest.Solde += trans.Montant;
                            statut.Etat = "OK";
                        }
                    }
                }
                //SINON SI Retrait
                else if (trans.NumeroDest == 0 && trans.NumeroExp != 0)
                {
                    cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                    if (cExp != null)
                    {
                        if (trans.Montant >= 0)
                        {
                            if (cExp.Solde >= trans.Montant)
                            {
                                cExp.Solde -= trans.Montant;
                                statut.Etat = "OK";
                            }
                        }
                    }
                }
                //SINON SI Virement/Prélèvement
                else if (trans.NumeroDest != 0 && trans.NumeroExp != 0)
                {
                    cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                    cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                    if (cExp != null || cDest != null)
                    {
                        if (trans.Montant >= 0)
                        {
                            if (cExp.Solde >= trans.Montant)
                            {
                                cExp.Solde -= trans.Montant;
                                cDest.Solde += trans.Montant;
                                statut.Etat = "OK";
                            }
                        }
                    }
                }
                statuts.Add(statut);
            }

            return statuts;

            //for (int i = 0; i < transactions.Count; i++)
            //{
            //    //Depot
            //    if (transactions[3](i) == 0)
            //    {
            //        c.Solde(i) += t.Montant(i);
            //    }
            //    //Retrait
            //    else if (t.NumeroExp(i) == i && t.NumeroDest(i) == 0 && c.Solde(i) >= t.Montant(i))
            //    {
            //        c.Solde(i) -= t.Montant(i);
            //    }
            //    //Virement
            //    else if (t.NumeroExp(i) == i && c.Solde(i) >= t.Montant(i) && c.Solde(t.NumeroDest(i)) >= t.Montant(i))
            //    {
            //        c.Solde(i) -= t.Montant(i);
            //        c.Solde(t.NumeroDest(i)) += t.Montant(i);
            //    }
            //    return traitement.Statuts = "KO";
            //}
            //return traitement;

            ////Ecriture fichier de sortie
            //File.WriteAllLines(sttsPath, traitement);
        }
    }
}
