using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace C_aiguisé
{
    public class Player : Character
    {

        private Weapon _wWeapon;
        private Role _role;
        private int _summonBar;
        public Role _mRole
        {
            get { return _role; }
            protected set { _role = value; }
        }

        public int _mSummonBar
        {
            get { return _summonBar; }
            set { _summonBar = value; }
        }

        public Player(string name, Weapon weapon, Role role)
        {
            _name = name;
            _wWeapon = weapon;
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
            _sprite = "gentil";
            _role.setPlayer(this);
        }

        public int Attack()
        {
            int damage = _wWeapon.GetDamage();
            return damage;
        }



        public void Heal(int heal)
        {
            if (_hp < 100)
            {
                _hp += heal;
            }
        }

        public void GetExp(int exp)
        {
            _exp += exp;
        }
        public override void Update() { }
    }
}