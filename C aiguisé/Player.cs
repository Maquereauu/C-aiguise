using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace C_aiguisé
{
    public class Player : Character
    {
        
        private Weapon _weapon;
        private string _role;
        public Player(string name, float hp, float mp, float strength, float level, float exp, float critChance, float critDamage,float dodgeChance, float speed, string sprite, Weapon weapon, string role) 
        {
            _weapon = weapon;
            _role = role;
            _strength = strength;
            _name = name;
            _hp = hp;
            _hpMax = hp;
            _mp = mp;
            _mpMax = mp;
            _strength = strength;
            _level = level; 
            _exp = exp;
            _critChance = critChance;
            _critDamage = critDamage;
            _dodgeChance = dodgeChance;
            _speed = speed;
            _sprite = sprite;
            _role = role;




        }

        public void Attack(Ennemy ennemy)
        {
            ennemy.TakeDamage(_weapon._mdamage);
        }

        public void TakeDamage(float damage) { 
            _hp -= damage;
        }

        public void Heal(int heal)
        {
           if(_hp < 100)
            {
                _hp += heal;
            }
        }
       /* public Summon Summon() {
            Summon summon = new Summon();
            return summon;
        }*/
    }
}