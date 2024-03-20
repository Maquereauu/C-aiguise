using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace C_aiguisé
{
    public class Ennemy : Character
    {

       
        private string _type;

        public Ennemy(string name, float hp, float mp, float strength, float level, float exp, float critChance, float critDamage, float dodgeChance, float speed, string sprite, string type)
        {
           
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
            _type = type;



        }

        public void Attack(Player player)
        {
            player.TakeDamage(_strength);
        }

        public void Attack(Summon summon)
        {
            summon.TakeDamage(_strength);
        }

        public void TakeDamage(float damage)
        {
            _hp -= damage;
        }

        public void Heal(int heal)
        {
            if (_hp < 100)
            {
                _hp += heal;
            }
        }
    }
}