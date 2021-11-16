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
    }
}
