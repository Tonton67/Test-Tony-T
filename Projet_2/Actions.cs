using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public static class Actions
    {
        public static List<Gestionnaire> LectureGestionnaire(string gestPath)
        {
            //Déclaration de la liste
            List<Gestionnaire> gestionnaires = new List<Gestionnaire>();
            int convers;

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(gestPath);

            //Séparation des données
            foreach (string line in lines)
            {
                int identifiant;
                string type;
                int nbtransactions;

                Console.WriteLine($"Fichier G : {line}");
                string[] split = line.Split(';');

                ////Affichage console
                //for (int i = 0; i < split.Length; i++)
                //{
                //    Console.WriteLine($" Infos Split C{i} : {split[i]}");
                //}

                identifiant = int.Parse(split[0]);
                type = split[1];
                nbtransactions = int.Parse(split[2]);


                ////Cas où le solde est nul ou vide ou espace
                //if (string.IsNullOrWhiteSpace(split[1]))
                //{
                //    solde = 0;
                //}
                //else
                //{
                //    solde = decimal.Parse(split[1].Replace(".", ","));
                //}
                //if (numero != 0 && solde >= 0)
                //{


                //Création de compte
                Gestionnaire g = new Gestionnaire(identifiant, type, nbtransactions);
                //Ajout des données dans la liste Compte
                gestionnaires.Add(g);

                //}

            }

            return gestionnaires;
        }

        public static List<Compte> LectureCompte(string accpPath)
        {
            //Déclaration de la liste
            List<Compte> comptes = new List<Compte>();
            //List<int> cNum = new List<int>();

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(accpPath);

            //Séparation des données
            foreach (string line in lines)
            {
                int identifiant;
                DateTime date;
                decimal solde;
                int entree;
                int sortie;

                Console.WriteLine($"Fichier C : {line}");
                string[] split = line.Split(';');

                ////Affichage console
                //for (int i = 0; i < split.Length; i++)
                //{
                //    Console.WriteLine($" Infos Split C{i} : {split[i]}");
                //}

                identifiant = int.Parse(split[0]);
                date = DateTime.Parse(split[1]);

                //entree = int.Parse(split[3]);
                //sortie = int.Parse(split[4]);


                //Cas où l'entrée est nulle ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[3]))
                {
                    entree = 0;
                }
                else
                {
                    entree = int.Parse(split[3]);
                }

                //Cas où la sortie est nulle ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[4]))
                {
                    sortie = 0;
                }
                else
                {
                    sortie = int.Parse(split[4]);
                }


                //Cas où le solde est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[2]))
                {
                    //Compte cSortie = comptes.Find(cpt => cpt.Identifiant == line[4]);
                    //if (cSortie != null && string.IsNullOrWhiteSpace(split[2]))
                    //{

                    solde = 0;
                    //}

                }

                else
                {
                    solde = decimal.Parse(split[2].Replace(".", ","));
                }

                if (identifiant != 0 && solde >= 0)
                //if (identifiant != 0 && CompteExistant(identifiant, comptes) == false)

                //{
                //    if (!cNum.Any(x => x == identifiant))
                {

                    //Création de compte
                    Compte c = new Compte(identifiant, date, solde, entree, sortie);
                    //cNum.Add(c.Identifiant);

                    //Ajout des données dans la liste Compte
                    comptes.Add(c);
                }
                //}
            }
            return comptes;
        }

        public static bool CompteExistant(int identifiant, List<Compte> comptes)
        {
            if (comptes.Any(x => x.Identifiant == identifiant))
            {
                return true;
            }
            return false;
        }

        public static List<Transaction> LectureTransaction(string trxnPath)
        {
            //Déclaration de la liste
            List<Transaction> transactions = new List<Transaction>();

            //Lecture du fichier Compte
            string[] lines = File.ReadAllLines(trxnPath);

            //Séparation des données
            foreach (string line in lines)
            {
                //Transaction t = new Transaction(0, 0, 0, 0);

                int identifiant;
                DateTime dateEffet;
                decimal montant;
                int numeroExp;
                int numeroDest;

                Console.WriteLine($"Fichier : {line}");
                string[] split = line.Split(';');

                ////Affichage console
                //for (int i = 0; i < split.Length; i++)
                //{
                //    Console.WriteLine($" Infos Split T{i} : {split[i]}");
                //}

                identifiant = int.Parse(split[0]);
                dateEffet = DateTime.Parse(split[1]);


                //Cas où le numéro expéditeur est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[3]))
                {
                    numeroExp = 0;
                }
                else
                {
                    numeroExp = int.Parse(split[3]);
                }

                //Cas où le numéro destinataire est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[4]))
                {
                    numeroDest = 0;
                }
                else
                {
                    numeroDest = int.Parse(split[4]);
                }


                //Cas où le montant est nul ou vide ou espace
                if (string.IsNullOrWhiteSpace(split[2]))
                {
                    montant = 0;
                }
                else
                {
                    montant = decimal.Parse(split[2].Replace(".", ","));
                }

                Transaction t = new Transaction(identifiant, dateEffet, montant, numeroExp, numeroDest);

                //Ajout des données dans la liste Transaction
                transactions.Add(t);
            }
            return transactions;
        }

        public static List<StatutTransaction> TraitementTransaction(List<Transaction> transactions, List<Compte> comptes)
        {
            List<StatutTransaction> statutsTr = new List<StatutTransaction>();
            List<int> transacNum = new List<int>();

            foreach (var trans in transactions)
            {
                StatutTransaction statutTr = new StatutTransaction(trans.Identifiant, "KO");
                Compte cExp;
                Compte cDest;


                if ()
                {

                }


                //Recherche si le numéro de transaction n'a pas déjà été traité
                if (!transacNum.Any(x => x == trans.Identifiant))
                {
                    //SI Dépôt
                    if (trans.NumeroExp == 0 && trans.NumeroDest != 0)
                    {
                        //Recherche du compte destinataire dans la liste Compte
                        cDest = comptes.Find(cpt => cpt.Identifiant == trans.NumeroDest);
                        //SI Le Compte est trouvé dans la liste Compte
                        if (cDest != null)
                        {
                            //SI Le montant est positif
                            if (trans.Montant > 0)
                            {
                                cDest.Solde += trans.Montant;
                                statutTr.Statut = "OK";
                            }
                        }
                    }
                    //SINON SI Retrait
                    else if (trans.NumeroDest == 0 && trans.NumeroExp != 0)
                    {
                        //Recherche du compte expéditeur dans la liste Compte
                        cExp = comptes.Find(cpt => cpt.Identifiant == trans.NumeroExp);
                        //SI Le Compte est trouvé dans la liste Compte
                        if (cExp != null)
                        {
                            //SI Le montant est positif
                            if (trans.Montant > 0)
                            {
                                if (cExp.Solde >= trans.Montant)
                                {
                                    cExp.Solde -= trans.Montant;
                                    statutTr.Statut = "OK";
                                }
                            }
                        }
                    }
                    //SINON SI Virement/Prélèvement
                    else if (trans.NumeroDest != 0 && trans.NumeroExp != 0)
                    {
                        //Recherche des comptes destinataire et expéditeur dans la liste Compte
                        cDest = comptes.Find(cpt => cpt.Identifiant == trans.NumeroDest);
                        cExp = comptes.Find(cpt => cpt.Identifiant == trans.NumeroExp);
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
                                    statutTr.Statut = "OK";
                                }
                            }
                        }
                    }
                }
                //Ajout de la transaction à la liste pour vérifier du numéro de transaction
                transacNum.Add(trans.Identifiant);
                //Ajout des données dans la liste Statut
                statutsTr.Add(statutTr);
            }
            return statutsTr;
        }

        public static List<StatutOperation> TraitementOperation(List<Transaction> transactions, List<Compte> comptes)
        {
            List<StatutOperation> statutsOpe = new List<StatutOperation>();
            List<int> operationNum = new List<int>();

            foreach (var ope in comptes)
            {
                StatutOperation statutOpe = new StatutOperation(ope.Identifiant, "KO");

                //Compte cExp;
                //Compte cDest;

                //Recherche si le numéro de transaction n'a pas déjà été traité
                if (!operationNum.Any(x => x == ope.Identifiant))
                {
                    ////SI Dépôt
                    //if (ope.NumeroExp == 0 && ope.NumeroDest != 0)
                    //{
                    //    //Recherche du compte destinataire dans la liste Compte
                    //    cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                    //    //SI Le Compte est trouvé dans la liste Compte
                    //    if (cDest != null)
                    //    {
                    //        //SI Le montant est positif
                    //        if (trans.Montant > 0)
                    //        {
                    //            cDest.Solde += trans.Montant;
                    //            statut.Etat = "OK";
                    //        }
                    //    }
                    //}
                    ////SINON SI Retrait
                    //else if (trans.NumeroDest == 0 && trans.NumeroExp != 0)
                    //{
                    //    //Recherche du compte expéditeur dans la liste Compte
                    //    cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                    //    //SI Le Compte est trouvé dans la liste Compte
                    //    if (cExp != null)
                    //    {
                    //        //SI Le montant est positif
                    //        if (trans.Montant > 0)
                    //        {
                    //            if (cExp.Solde >= trans.Montant)
                    //            {
                    //                cExp.Solde -= trans.Montant;
                    //                statut.Etat = "OK";
                    //            }
                    //        }
                    //    }
                    //}
                    ////SINON SI Virement/Prélèvement
                    //else if (trans.NumeroDest != 0 && trans.NumeroExp != 0)
                    //{
                    //    //Recherche des comptes destinataire et expéditeur dans la liste Compte
                    //    cDest = comptes.Find(cpt => cpt.Numero == trans.NumeroDest);
                    //    cExp = comptes.Find(cpt => cpt.Numero == trans.NumeroExp);
                    //    //SI Les Comptes ont été trouvé dans la liste Compte
                    //    if (cExp != null || cDest != null)
                    //    {
                    //        //SI Le montant est positif
                    //        if (trans.Montant > 0)
                    //        {
                    //            //SI Le solde du compte expéditeur est supérieur ou égal au montant
                    //            if (cExp.Solde >= trans.Montant)
                    //            {
                    //                cExp.Solde -= trans.Montant;
                    //                cDest.Solde += trans.Montant;
                    //                statut.Etat = "OK";
                    //            }
                    //        }
                    //    }
                    //}
                }
                //Ajout de l'opération à la liste pour vérifier du numéro d'opération
                operationNum.Add(ope.Identifiant);
                //Ajout des données dans la liste Statut
                statutsOpe.Add(statutOpe);
            }
            return statutsOpe;
        }
    }
}
