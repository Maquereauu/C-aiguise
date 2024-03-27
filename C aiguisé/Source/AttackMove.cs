using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class AttackMove
    {
        int _type;
        bool _isMagic;
        int _damage;
        int _mpCost;
        bool _isAoe;
        bool _isTargetingEnemy;
        public AttackMove(int type,bool magic,int damage,int mpCost,bool isAoe,bool isTargetingEnemy) { 
            _type = type;
            _isMagic = magic;
            _damage = damage;
            _mpCost = mpCost;
            _isAoe = isAoe;
            _isTargetingEnemy = isTargetingEnemy;
        }
    }
}