using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Enemy : GameObject
    {
        private string _sName;
        private int _iHp;
        private int _iMp;
        private int _iLevel;
        private float _fExp;
        /*private int _iCritChance = 5;
        private int _iCritDamage = 0;*/
        private int _iDodgeChance = 0;
        private string _sType;
        private float _speed;
        private string _sSprite;//?
        public float _mSpeed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Enemy()
        {
            _iHp = 100;
            _iMp = 100;
            _iLevel = 1;
            _fExp = 0.0f;
            _iDodgeChance = 0;
            _speed = 0.5f;
        }
    }
}