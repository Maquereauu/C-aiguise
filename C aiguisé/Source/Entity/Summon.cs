using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Summon : Character
    {
        public Summon() : base("")
        {
            _hpMax = 100;
            _mpMax = 100;
            _hp = _hpMax;
            _mp = _mpMax;
            _level = 1;
            _exp = 0.0f;
            _dodgeChance = 0;
            _speed = 0.5f;
        }
        public override void Update()
        {
            base.Update();
        }
    }

}
