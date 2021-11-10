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
                if (_full[_size - 1, i])
                {
                    return true;
                }
            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> _voisins = new List<KeyValuePair<int, int>>();

            //if (!i < 0 || i < _size - 1 || j < 0 || j < _size - 1)
            //{
            //    return null;
            //}



            if (i > 0)
            {
                _voisins.Add(new KeyValuePair<int, int>(i - 1, j));
            }

            else if (i < _size - 1)
            {
                _voisins.Add(new KeyValuePair<int, int>(i + 1, j));
            }

            else if (j > 0)
            {
                _voisins.Add(new KeyValuePair<int, int>(i, j - 1));
            }

            else if (j < _size - 1)
            {
                _voisins.Add(new KeyValuePair<int, int>(i, j + 1));
            }

            return _voisins;


        }

        public void Open(int i, int j)
        {

            if (IsOpen(i, j) != true)
            {
                _open[i, j] = true;

                if (i == 0)
                {
                    _full[i, j] = true;
                }
                else
                {
                    foreach (KeyValuePair<int, int> _voisin in CloseNeighbors(i, j))
                    {
                        if (IsFull(_voisin.Key, _voisin.Value))
                        {
                            _full[i, j] = true;
                            break;
                        }

                    }

                }
                if (_full[i, j] == true)
                {
                    OpenNeighbors(i, j);
                }

            }
        }
        private void OpenNeighbors(int i, int j)
        {
            foreach (KeyValuePair<int, int> _voisin in CloseNeighbors(i, j))
            {
                if (IsOpen(_voisin.Key, _voisin.Value))
                {
                    _full[_voisin.Key, _voisin.Value] = true;
                    OpenNeighbors(_voisin.Key, _voisin.Value);
                }


            }



        }
    }
}
