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
        public Role _mRole
        {
            get { return _role; }
            protected set { _role = value; }
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
            _iLevel = 1;
            _fExp = 0.0f;
            _iDodgeChance = 0;
            _speed = 1.0f;
            _sprite = "gentil";
            _role.setPlayer(this);
        }

        public int Attack()
        {
            int damage = this._wWeapon.GetDamage();
            return damage;
        }


        public void Heal(int heal)
        {
            if (this._hp < 100)
            {
                this._hp += heal;
            }
        }


        public override void Update() { }
    }
}