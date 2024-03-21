using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Role
    {
        protected float _id;
        protected Player _player;
        public Role() 
        {
        }
        public void setPlayer(Player player)
        {
            _player = player;
        }
        public virtual void Update() { }

    }
}