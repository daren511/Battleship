using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;


namespace BattleShipDLL
{
    [Serializable]
    public class Navire
    {
        public string _nom { get; private set; }
        public List<Point> _coords = new List<Point>();
        public bool[] _isAlive { get; private set; }

        public int _size { get; private set; }

        public Navire(string name, List<Point> coords)
        {
            _nom = name;
            _coords = coords;
            _size = coords.Count();
            _isAlive = new bool[_size];

            for(int i = 0; i <_size; ++i)
            {
                _isAlive[i] = true;
            }
        }
        public bool NavireVivant()
        {
            int compteur = 0;

            for (int i = 0; i < _size; ++i )
            {
                if(!_isAlive[i])
                {
                    compteur++;
                }
            }
            return compteur != _size;
        }
    }
}
