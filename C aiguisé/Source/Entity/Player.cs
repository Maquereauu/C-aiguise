using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
        protected set { _weapon = value; }

        }

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
            _sprite = "gentil";
            _role.setPlayer(this);
            AddAttack(new AttackMove(0,40,false,true,"yo"));
        }

        public int Attack()
        {
            int damage = _weapon.GetDamage();
            return damage;
        }



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