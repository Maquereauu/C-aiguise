using Newtonsoft.Json;
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
        [JsonProperty]
        public int _mIdamage
        {
            get { return _iDamage; }
            set { _iDamage = value; }
        }
        [JsonProperty]
        public int _mCritRate
        {
            get { return _iCritRate; }
            set { _iCritRate = value; }
        }
        [JsonProperty]
        public int _mCritDamage
        {
            get { return _iCritDamage; }
            set { _iCritDamage = value; }
        }
        [JsonProperty]
        public string _mType
        {
            get { return _sType; }
            set { _sType = value; }
        }
        [JsonProperty]
        public string _mClass
        {
            get { return _sClass; }
            set { _sClass = value; }
        }

        public Weapon(string name) : base(name, true)
        {
            _iDamage = 10;
        }

        [JsonConstructor]
        public Weapon(string name, int iDamage, int iCritRate, int iCritDamage, string sType, string sClass) : base (name, true)
        {
            _iDamage = iDamage;
            _iCritRate = iCritRate;
            _iCritDamage = iCritDamage;
            _sType = sType;
            _sClass = sClass;
        }

        public int GetDamage()
        {
            return _iDamage;
        }
    }
}