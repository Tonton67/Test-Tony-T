using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class StatutOperation
    {
        public int Identifiant { get; set; }
        public string Etat { get; set; }
        public StatutOperation(int identifiant, string etat)
        {
            Identifiant = identifiant;
            Etat = etat;
        }
    }
}
