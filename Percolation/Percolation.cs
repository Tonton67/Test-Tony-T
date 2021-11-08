using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            if (_open[i, j])
            {
                return true;
            }

            return false;
        }

        public bool IsFull(int i, int j)
        {
            if (_full[i, j])
            {
                return true;
            }

            return false;
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_full[i, _size])
                {
                    Console.WriteLine("Il y a percolation.");
                    return true;
                }

                Console.WriteLine("Il n'y a pas de percolation.");
                return false;

            }

            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> _voisins = new List<KeyValuePair<int, int>>();


            if (i > 0)
            {
                _voisins.Add(new KeyValuePair<int, int>(i - 1, j));
            }

            if (i < _size - 1)
            {
                _voisins.Add(new KeyValuePair<int, int>(i + 1, j));
            }

            if (j > 0)
            {
                _voisins.Add(new KeyValuePair<int, int>(i, j - 1));
            }

            if (j < _size - 1)
            {
                _voisins.Add(new KeyValuePair<int, int>(i, j + 1));
            }

            return _voisins;


        }

        public void Open(int i, int j)
        {

            if (IsOpen(i,j) != true)
            {
                _open[i, j] = true;

                foreach (int _voisin in CloseNeighbors(i,j))
                {

                }

            }

           

                

        }
    }
}
