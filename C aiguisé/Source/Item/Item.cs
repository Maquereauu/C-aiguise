using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace C_aiguisé
{ 
    public class Item
    {
        private string _name;
        private bool _unique;

        public string _mName
        {
            get { return _name; }
            protected set { _name = value; }
        }
        public bool _mUnique
        {
            get { return _unique; }
            protected set { _unique = value; }
        }
        public Item(string name, bool unique)
        {
            _name = name;
            _unique = unique;
        }

        public string GetName()
        { 
            return _name; 
        }

        public bool IsUnique() 
        { 
            return _unique; 
        }
    }
}