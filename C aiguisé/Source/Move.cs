using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{

    public class Move
    {
        protected int _type;
        protected int _damage;
        protected bool _isAoe;
        protected bool _isTargetingEnemy;
        protected string _name;
        protected int _mpCost;

        [JsonProperty]
        public int _mType
        {
            get { return _type; }
            protected set { _type = value; }
        }
        [JsonProperty]
        public int _mDamage
        {
            get { return _damage; }
            protected set { _damage = value; }
        }
        [JsonProperty]
        public string _mName
        {
            get { return _name; }
            protected set { _name = value; }
        }
        [JsonProperty]
        public int _mMpCost
        {
            get { return _mpCost; }
            set { _mpCost = value; }
        }
        [JsonProperty]
        public bool _mIsAoe
        {
            get { return _isAoe; }
            protected set { _isAoe = value; }
        }
    }
}
