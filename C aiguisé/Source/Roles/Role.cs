using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Role
    {
        protected int _id;
        protected Player _player;

        [JsonProperty]
        public int _mId
        {
            get { return _id; }
            protected set { _id = value; }
        }

        public Role() 
        {
        }
        public void setPlayer(Player player)
        {
            _player = player;
        }
        public virtual void Update() { }
        
        public static Role CreateRole (int id)
        {
            switch (id)
            {
                case 0:
                    return new Archer();
                case 1:
                    return new Knight();
                case 2:
                    return new Tank();
                case 3:
                    return new WhiteWizard();
                case 4: 
                    return new BlackWizard();
            }
            throw new ArgumentException("This role id doesn't exist");
        }

    }
}