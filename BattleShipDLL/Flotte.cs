using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipDLL;

namespace BattleShipDLL
{
    [Serializable]
    public class Flotte
    {

        public List<Navire> flotte { get; private set; }
        public Flotte(List<Navire> list)
        {
            flotte = new List<Navire>();
            flotte = list;
        }

        public bool FlotteEstMorte()
        {
            int compteur = 0;
            for (int i = 0; i < flotte.Count; ++ i )
            {
                if(!flotte[i].NavireVivant())
                {
                    compteur++;
                }
            }
            return compteur == flotte.Count;
        }
    }
}
