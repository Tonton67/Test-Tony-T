using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class Compte
    {

        public int Identifiant { get; set; }
        public DateTime Date { get; set; }
        public decimal Solde { get; set; }
        public int Entree { get; set; }
        public int Sortie { get; set; }


        public Compte(int identifiant, DateTime date, decimal solde, int entree, int sortie)
        {
            Identifiant = identifiant;
            Date = date;
            Solde = solde;
            Entree = entree;
            Sortie = sortie;
        }


    }
}
