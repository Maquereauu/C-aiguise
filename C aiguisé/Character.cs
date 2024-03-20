using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace C_aiguisé
{
    public class Character
    {
        protected string _name;
        protected float _hpMax;
        protected float _hp;
        protected float _mpMax;
        protected float _mp;
        protected float _strength;
        protected float _level;
        protected float _exp;
        protected float _critChance ;
        protected float _critDamage ;
        protected float _dodgeChance ;
        protected float _speed;
        protected string _sprite;
        public float _mSpeed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Character()
        {
            
        }

        public virtual void Attack()
        {

        }

        public virtual void TakeDamage()
        {

        }

        public void Heal(float heal)
        {
            
        }
    }
}