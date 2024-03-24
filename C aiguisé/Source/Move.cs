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
        public int _mType
        {
            get { return _type; }
            protected set { _type = value; }
        }
        public int _mDamage
        {
            get { return _damage; }
            protected set { _damage = value; }
        }
    }
}
