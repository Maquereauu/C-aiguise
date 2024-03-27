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
        protected string _sprite;

        [JsonProperty]
        public int _mId
        {
            get { return _id; }
            protected set { _id = value; }
        }
        [JsonProperty]
        public string _mSprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        public Role(string sprite) 
        {
            _sprite = sprite;
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