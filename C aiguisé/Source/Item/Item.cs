using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{ 
    public class Item
    {
        private string _name;
        private bool _unique;

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