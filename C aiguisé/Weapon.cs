using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Weapon : Item
    {
        private int _damage;
        private int _critRate;
        private int _critDamage;
        private string _type = "";
        //unique effect
        private string _class = "";

        public Weapon() {
            _damage = 10;
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}