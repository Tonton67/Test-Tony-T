using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2
{
    public class Gestionnaire
    {

        public int Identifiant { get; set; }
        public string Type { get; set; }
        public int NbTransactions { get; set; }

        public Gestionnaire(int identifiant, string type, int nbtransactions)
        {
            Identifiant = identifiant;
            Type = type;
            NbTransactions = nbtransactions
        }


    }
}
