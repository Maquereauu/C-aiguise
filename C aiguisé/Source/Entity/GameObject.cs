using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace C_aiguisé
{
    public class GameObject
    {
        protected Transform _tranform;
        public Transform _mTranform
        {
            get { return _tranform; }
            protected set { _tranform = value; }
        }
        public GameObject()
        {
            _tranform = new Transform();
        }
    }
}