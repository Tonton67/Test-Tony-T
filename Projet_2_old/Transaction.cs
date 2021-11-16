using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class Transaction
    {

        public int Identifiant { get; set; }
        public DateTime DateEffet { get; set; }
        public decimal Montant { get; set; }
        public int NumeroExp { get; set; }
        public int NumeroDest { get; set; }

        public Transaction(int identifiant, DateTime dateeffet, decimal montant, int numeroExp, int numeroDest)
        {
            Identifiant = identifiant;
            DateEffet = dateeffet;
            Montant = montant;
            NumeroExp = numeroExp;
            NumeroDest = numeroDest;
        }
    }
}
