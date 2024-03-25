using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{ 
    public class MagicMove : Move
    {
        int _mpCost;
        public MagicMove(int type, int damage, int mpCost, bool isAoe, bool isTargetingEnemy,string name)
        {
            _type = type;
            _damage = damage;
            _mpCost = mpCost;
            _isAoe = isAoe;
            _isTargetingEnemy = isTargetingEnemy;
            _name = name;
        }
    }
}