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
            _hp = 100;
            _iMp = 100;
            _iLevel = 1;
            _fExp = 0.0f;
            _iDodgeChance = 0;
            _speed = 0.5f;
            _sprite = "méchant";
        }
        public override void Update()
        {

        }
    }
}