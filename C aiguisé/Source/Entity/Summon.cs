using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Summon : Character
    {
        public Summon(string sprite)
        {
            _hpMax = 100;
            _mpMax = 100;
            _hp = _hpMax;
            _mp = _mpMax;
            _level = 1;
            _exp = 0.0f;
            _dodgeChance = 0;
            _speed = 15;
            _sprite = sprite;

            (int, int) size = FileReader.GetSizeFromFile(_sprite);
            _tranform._mSize = new Utils.vect2(size.Item1, size.Item2);
        }
        public override void Update()
        {
            base.Update();
        }
    }

}
