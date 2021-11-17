using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class BaseCompte
    {

        public int Identifiant { get; set; }
        public decimal Solde { get; set; }
        public decimal MontantMaxRetrait { get; set; }
        public DateTime DateOuv { get; set; }
        public DateTime DateFerm { get; set; }
        public List<Transaction> Historique { get; set; }



        public BaseCompte(int identifiant, decimal solde, decimal montantMaxRetrait, DateTime dateOuv, DateTime dateFerm, List<Transaction> historique)
        {
            Identifiant = identifiant;
            Solde = solde;
            MontantMaxRetrait = montantMaxRetrait;
            DateOuv = dateOuv;
            DateFerm = dateFerm;
            Historique = historique;

        }


    }
}