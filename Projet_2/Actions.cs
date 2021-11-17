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

                identifiant = int.Parse(split[0]);
                type = split[1];
                nbtransactions = int.Parse(split[2]);

                //Création de gestionnaire
                Gestionnaire g = new Gestionnaire(identifiant, type, nbtransactions);
                //Ajout des données dans la liste Gestionnaire
                gestionnaires.Add(g);
            }
            return gestionnaires;
        }

        public static List<Compte> LectureCompte(List<Gestionnaire> gestionnaires, List<StatutOperation> statutOperations, string accpPath)
        {
            //Déclaration de la liste
            List<Compte> comptes = new List<Compte>();

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
                DateTime dateOuv = DateTime.MinValue;
                DateTime dateFerm = DateTime.MaxValue;

                //Séparation des données du fichier d'entrée
                string[] split = line.Split(';');

                //Conversion des données d'entrée
                identifiant = int.Parse(split[0]);
                date = DateTime.Parse(split[1]);

                //Initialisation du statut des opérations
                StatutOperation sOpe = new StatutOperation(identifiant);

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
                    solde = 0;
                }

                else
                {
                    solde = decimal.Parse(split[2].Replace(".", ","));
                }

                //Déterminer nature de l'opération
                //SI Création compte
                if (entree != 0 && sortie == 0)
                {
                    if (identifiant != 0 && solde >= 0 && CompteExistant(identifiant, comptes) == false)

                    {
                        foreach (var gest in gestionnaires)
                        {
                            if (entree == gest.Identifiant)
                            {
                                //Création d'un compte
                                Compte c = new Compte(identifiant, date, solde, entree, sortie, dateOuv, dateFerm);

                                //Affectation date d'ouverture du compte
                                c.DateOuv = date;
                                //Retour statut "OK"
                                sOpe.Etat = "OK";
                                //Ajout des données dans la liste Compte
                                comptes.Add(c);

                            }

                        }

                    }
                }
                //SINON SI Suppression compte
                if (entree == 0 && sortie != 0)
                {
                    if (solde == 0 && sortie == identifiant)
                    {
                        foreach (var cpt in comptes)
                        {
                            if (identifiant == cpt.Identifiant)
                            {
                                //Affectation date de fermeture du compte
                                cpt.DateFerm = date;
                                //Retour Statut "OK"
                                sOpe.Etat = "OK";

                            }
                        }
                    }
                }
                //SINON SI Modification compte
                if (entree != 0 && sortie != 0 && solde == 0)
                {
                    //Parcourir la liste Compte pour ....
                    foreach (var cpt in comptes)
                    {
                        if (identifiant == cpt.Identifiant)
                        {
                            //... Comparer le gestionnaire
                            if (entree == cpt.Entree)
                            {
                                //Si le gestionnaire est le bon : modification du gestionnaire
                                cpt.Entree = sortie;
                                //Retour Statut "OK"
                                sOpe.Etat = "OK";
                            }
                        }
                    }
                }
                statutOperations.Add(sOpe);
            }
            return comptes;
        }

        private static bool CompteExistant(int identifiant, List<Compte> comptes)
        {
            //Contrôle de l'existence du compte dans la liste de Compte
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

            //Séparation des données d'entrée
            foreach (string line in lines)
            {
                int identifiant;
                DateTime dateEffet;
                decimal montant;
                int numeroExp;
                int numeroDest;

                //Console.WriteLine($"Fichier : {line}");

                //Séparation des données du fichier d'entrée
                string[] split = line.Split(';');

                //Conversion des données
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

                //Création d'une transaction
                Transaction t = new Transaction(identifiant, dateEffet, montant, numeroExp, numeroDest);

                //Ajout des données dans la liste Transaction
                transactions.Add(t);
            }
            return transactions;
        }

        public static List<StatutTransaction> TraitementTransaction(List<Transaction> transactions, List<Compte> comptes)
        {
            //Déclaration de la liste Statut Transaction
            List<StatutTransaction> statutsTr = new List<StatutTransaction>();
            //Déclaration de la liste pour vérifier qu'il n'y a pas de doublon de transaction
            List<int> transacNum = new List<int>();

            //Parcours de la liste Transaction
            foreach (var trans in transactions)
            {
                //Déclaration de variables
                StatutTransaction statutTr = new StatutTransaction(trans.Identifiant);
                Compte cExp;
                Compte cDest;

                //Parcours de la liste Compte
                foreach (var cpt in comptes)
                {
                    //Recherche si le numéro de transaction n'a pas déjà été traité
                    if (!transacNum.Any(x => x == trans.Identifiant))
                    {
                        //Vérification de la date d'effet de la transaction devant être comprise entre les dates d'ouverture et de fermeture des comptes
                        if (trans.DateEffet > cpt.DateOuv && trans.DateEffet < cpt.DateFerm)
                        {
                            //SI Dépôt
                            if (trans.NumeroExp == 0 && trans.NumeroDest != 0)
                            {
                                //Recherche du compte destinataire dans la liste Compte
                                cDest = comptes.Find(cpts => cpts.Identifiant == trans.NumeroDest);
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
                                cExp = comptes.Find(cpts => cpts.Identifiant == trans.NumeroExp);
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
                                cDest = comptes.Find(cpts => cpts.Identifiant == trans.NumeroDest);
                                cExp = comptes.Find(cpts => cpts.Identifiant == trans.NumeroExp);
                                //SI Les Comptes ont été trouvé dans la liste Compte
                                if (cExp != null || cDest != null)
                                {
                                    //Vérifications de la date d'effet par rapport aux dates d'ouverture et de fermeture des comptes expéditeurs et destinataires
                                    if (trans.DateEffet > cExp.DateOuv && trans.DateEffet < cExp.DateFerm && trans.DateEffet > cDest.DateOuv && trans.DateEffet < cDest.DateFerm)
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
                        }

                        //Ajout de la transaction à la liste pour vérifier du numéro de transaction
                        transacNum.Add(trans.Identifiant);
                        //Ajout des données dans la liste Statut
                        statutsTr.Add(statutTr);
                    }

                }

            }
            return statutsTr;
        }
    }
}
