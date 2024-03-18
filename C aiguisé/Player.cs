using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace C_aiguisé
{
    public class Player
    {
        private string _sName;
        private int _iHp;
        private int _iMp;
        private Weapon _wWeapon;
        private int _iLevel;
        private float _fExp;
/*      private int _iCritChance ;
        private int _iCritDamage ;*/
        private int _iDodgeChance ;
        private string _sClasse;
        private float _fSpeed;
        private string _sSprite;//?

        public Player(string name, Weapon weapon, string classe)
        {
            _sName = name;
            _wWeapon = weapon;
            _sClasse = classe;
            _iHp = 100;
            _iMp = 100;
            _iLevel = 1;
            _fExp = 0.0f;
            _iDodgeChance = 0;
            _fSpeed = 1.0f;
        }

        public void Attack()
        {
            int damage = this._wWeapon.GetDamage();
        }

        public void TakeDamage() { 
        
        }

        public void Heal(int heal)
        {
           if(this._iHp < 100)
            {
                this._iHp += heal;
            }
        }
    }
}