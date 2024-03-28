using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class AttackMove : Move
    {
        public AttackMove(int type,int damage,bool isAoe,bool isTargetingEnemy,string name) { 
            _type = type;
            _damage = damage;
            _isAoe = isAoe; 
            _isTargetingEnemy = isTargetingEnemy;
            _name = name;
        }
    }
}