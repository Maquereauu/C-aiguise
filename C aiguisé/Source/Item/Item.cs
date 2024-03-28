using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace C_aiguisé
{ 
    public class Item
    {
        protected string _name;
        protected bool _unique;

        [JsonProperty]
        public string _mName
        {
            get { return _name; }
            protected set { _name = value; }
        }
        [JsonProperty]
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

        public virtual void Update(Player player)
        {
            Bag.RemoveItem(this);
        }
    }
}