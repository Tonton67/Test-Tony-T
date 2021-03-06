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
                int numero;
                decimal solde;

                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');

                ////Affichage console
                //for (int i = 0; i < split.Length; i++)
                //{
                //    Console.WriteLine($" Infos Split C{i} : {split[i]}");
                //}

                numero = int.Parse(split[0]);
                //Cas où le solde est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[1]))
                {
                    solde = 0;
                }
                else
                {
                    solde = decimal.Parse(split[1].Replace(".", ","));
                }
                if (numero != 0 && solde >= 0)
                {
                    //Création de compte
                    Compte c = new Compte(numero, solde);
                    //Ajout des données dans la liste Compte
                    comptes.Add(c);
                }
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

                ////Affichage console
                //for (int i = 0; i < split.Length; i++)
                //{
                //    Console.WriteLine($" Infos Split T{i} : {split[i]}");
                //}

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
            List<int> transacNum = new List<int>();

            foreach (var trans in transactions)
            {
                Statut statut = new Statut(trans.Numero, "KO");
                Compte cExp;
                Compte cDest;

                //Recherche si le numéro de transaction n'a pas déjà été traité
                if (!transacNum.Any(x => x == trans.Numero))
                {
                    //SI Dépôt
                    if (trans.NumeroExp == 0 && trans.NumeroDest != 0)
                    {
                        //Recherche du compte destinataire dans la liste Compte
                        cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                        //SI Le Compte est trouvé dans la liste Compte
                        if (cDest != null)
                        {
                            //SI Le montant est positif
                            if (trans.Montant > 0)
                            {
                                cDest.Solde += trans.Montant;
                                statut.Etat = "OK";
                            }
                        }
                    }
                    //SINON SI Retrait
                    else if (trans.NumeroDest == 0 && trans.NumeroExp != 0)
                    {
                        //Recherche du compte expéditeur dans la liste Compte
                        cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                        //SI Le Compte est trouvé dans la liste Compte
                        if (cExp != null)
                        {
                            //SI Le montant est positif
                            if (trans.Montant > 0)
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
                        //Recherche des comptes destinataire et expéditeur dans la liste Compte
                        cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                        cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                        //SI Les Comptes ont été trouvé dans la liste Compte
                        if (cExp != null || cDest != null)
                        {
                            //SI Le montant est positif
                            if (trans.Montant > 0)
                            {
                                //SI Le solde du compte expéditeur est supérieur ou égal au montant
                                if (cExp.Solde >= trans.Montant)
                                {
                                    cExp.Solde -= trans.Montant;
                                    cDest.Solde += trans.Montant;
                                    statut.Etat = "OK";
                                }
                            }
                        }
                    }
                }
                //Ajout de la transaction à la liste pour vérifier du numéro de transaction
                transacNum.Add(trans.Numero);
                //Ajout des données dans la liste Statut
                statuts.Add(statut);
            }
            return statuts;
        }
    }
}
