using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Enemy : Character
    {
        public Enemy()
        {
            _name = "mon ennemi oh la misère";
            _hpMax = 100;
            _mpMax = 100;
            _hp = _hpMax;
            _mp = _mpMax;
            _level = 1;
            _exp = 0.0f;
            _dodgeChance = 0;
            _speed = 0.5f;
            _sprite = "méchant";
        }
        public override void Update()
        {

        }
    }
}