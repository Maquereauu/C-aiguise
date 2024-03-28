using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace C_aiguisé
{
    public class Player : Character
    {
        float _expToLevelUp;

        protected Weapon _weapon ;
        protected Role _role;
        protected int _summonBar = 0;
        public Weapon _mWeapon
        {
            get { return _weapon; }
            set { _weapon = value; }

        }

        public Role _mRole
        {
            get { return _role; }
            set { _role = value; }
        }

        public int _mSummonBar
        {
            get { return _summonBar; }
            set { _summonBar = value; }
        }
        [JsonProperty]
        public float _mExpToLevelUp
        {
            get { return _expToLevelUp; }
            set { _expToLevelUp = value; }
        }

        [JsonConstructor]
        public Player(){ }

        public Player(string name, Weapon weapon, Role role)
        {
            _name = name;
            _weapon = weapon;
            _role = role;
            _hpMax = 100;
            _mpMax = 100;
            _hp = _hpMax;
            _mp = _mpMax;
            _level = 1;
            _exp = 0.0f;
            _dodgeChance = 0;
            _speed = 20;
            _summonBar = 0;
            _sprite = _role._mSprite;
            _role.setPlayer(this);
            _expToLevelUp = 200;

            (int, int) size = FileReader.GetSizeFromFile(_sprite);
            _tranform._mSize = new Utils.vect2(size.Item1, size.Item2);
        }

        public Player(string name, float hp, float hpMax, float mp, float mpMax, int level, float exp,
            int critChance, int critDamage, int dodgeChance, int type, int speed, bool isDead, float expToLevelUp,
            List<AttackMove> attackMove, int summonBar, Weapon weapon, Role role)
        {
            _name = name;
            _weapon = weapon;
            _role = role;
            _hpMax = hpMax;
            _mpMax = mpMax;
            _hp = hp;
            _mp = mp;
            _level = level;
            _exp = exp;
            _dodgeChance = dodgeChance;
            _speed = speed;
            _summonBar = summonBar;
            _sprite = _role._mSprite;
            _critChance = critChance;
            _critDamage = critDamage;
            _type = type;
            _isDead = isDead;
            _role.setPlayer(this);
            AddAttack(attackMove);
            _expToLevelUp = expToLevelUp;

            (int, int) size = FileReader.GetSizeFromFile(_sprite);
            _tranform._mSize = new Utils.vect2(size.Item1, size.Item2);
        }


/*        public int Attack()
        {
            int damage = _weapon.GetDamage();
            return damage;
        }*/



        public void Heal(int heal)
        {
            if (_hp < _hpMax)
            {
                _hp += heal;
            }
            if(_hp > _hpMax)
            {
                _hp = _hpMax;
            }
        }

        public void HealMp(int mp)
        {
            if (_mp < _mpMax)
            {
                _mp += mp;
            }
            if (_mp > _mpMax)
            {
                _mp = _mpMax;
            }
        }


        public Role GetRole()
        { 
            return _role; 
        }

        public void AddExp(int exp)
        {
            _exp += exp;
        }

        public void LevelUp()
        {
            while (_exp >= _expToLevelUp)
            {
                _exp -= _expToLevelUp;
                if (_exp < 0)
                {
                    _exp = 0;
                }
                _expToLevelUp = (float)(_expToLevelUp + _expToLevelUp * 0.2);
                _level += 1;
                _hpMax += 15;
                _mpMax += 4;
            }
        }
        public override void Update() { }
    }
}