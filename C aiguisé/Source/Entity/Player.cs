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
        private string _sClasse;

        public Player(string name, Weapon weapon, string classe)
        {
            _sName = name;
            _wWeapon = weapon;
            _sClasse = classe;
            _hp = 100;
            _iMp = 100;
            _iLevel = 1;
            _fExp = 0.0f;
            _iDodgeChance = 0;
            _speed = 1.0f;
            _sprite = "gentil";
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