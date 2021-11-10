using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_1
{
    public class Statut
    {
        public int Numero { get; set; }
        public string Statuts { get; set; }
        public Statut(int numero, string statut)
        {
            Numero = numero;
            Statuts = statut;
        }
    }
}
