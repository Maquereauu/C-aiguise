﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class AttackMove : Move
    {
        public AttackMove(int type,int damage,bool isAoe,bool isTargetingEnemy) { 
            _type = type;
            _damage = damage;
            _isAoe = isAoe; 
            _isTargetingEnemy = isTargetingEnemy;
        }
    }
}