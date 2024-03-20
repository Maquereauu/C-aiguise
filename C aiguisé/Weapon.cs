using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Weapon : Item
    {

        private float _damage;
        public float _mdamage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        private float _critRate;
        private float _critDamage;
        private string _type = "";
        //unique effect
        private string _class = "";

        public Weapon(float damage) {
            _damage = damage;
        }

        
    }
}