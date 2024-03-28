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
            _speed = 1.0f;
            _summonBar = 0;
            _sprite = _role._mSprite;
            _role.setPlayer(this);
            AddAttack(new AttackMove(0,40,false,true,"yo"));

            (int, int) size = FileReader.GetSizeFromFile(_sprite);
            _tranform._mSize = new Utils.vect2(size.Item1, size.Item2);
        }

        public Player(string name, float hp, float hpMax, float mp, float mpMax, int level, float exp,
            int critChance, int critDamage, int dodgeChance, int type, float speed, bool isDead,
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
            if (_hp < 100)
            {
                _hp += heal;
            }
        }

        public Role GetRole()
        { 
            return _role; 
        }

        public void GetExp(int exp)
        {
            _exp += exp;
        }
        public override void Update() { }
    }
}