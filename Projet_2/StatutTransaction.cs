using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class StatutTransaction
    {
        public int Identifiant { get; set; }
        public string Statut { get; set; }
        public StatutTransaction(int identifiant, string statut)
        {
            Identifiant = identifiant;
            Statut = statut;
        }
    }
}