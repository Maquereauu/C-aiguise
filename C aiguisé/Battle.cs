using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Battle
    {
        private List<GameObject> _allies;
        private List<GameObject> _summons;
        private List<GameObject> _enemies;
        private List<int> _speeds;
        private int _indexSpeedList;
        private int _maxSpeed;
        public Battle(List<GameObject> allies, List<GameObject> summons, List<GameObject> enemies) {
            _allies = allies;
            _summons = summons;
            _enemies = enemies;
            for (int i = 0; i < allies.Count; i++)
            {
               /* _speeds.Add(_allies[i]._speed);*/
            }
            _indexSpeedList = 0;
            _maxSpeed = 0;
        }
        public void checkTurn()
        {
            for (int i = 0; i < _speeds.Count; i++)
            {
                
            }
        }
    }
}