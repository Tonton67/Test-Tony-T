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
    }
}
