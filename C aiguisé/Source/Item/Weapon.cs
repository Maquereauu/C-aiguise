using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Weapon : Item
    {
        private int _iDamage;
        private int _iCritRate;
        private int _iCritDamage;
        private string _sType = "";
        //unique effect
        private string _sClass = "";

        public Weapon(string name) : base(name, true)
        {
            _iDamage = 10;
        }

        public int GetDamage()
        {
            return _iDamage;
        }
    }
}