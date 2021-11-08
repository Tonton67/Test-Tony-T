using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            int k = 0;
            Random rnd = new Random();
            //Initialiser une grille de taille N *N avec l'ensemble des cases bloquées.
            Percolation percolation = new Percolation(size);
            //Choisir aléatoirement une case bloquée et l'ouvrir.
            do
            {
                int i = rnd.Next(0, size);
                int j = rnd.Next(0, size);
                percolation.Open(i, j);
                k += 1;
                //Tester si la percolation se produit.
            } while (!percolation.Percolate());
            //Réaliser la deuxième et troisième étape jusqu'à ce que la percolation est lieue.
            //Retourner la valeur cases ouvertes / nombre total de cases
            

            return k / (size*size);

        }
    }
}
