using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{ 
    class Ether : Consumable
    {
        float _mp;
        public Ether(float mp) : base ("Ether")
        {
            _mp = mp;
        }

        public override void Update(Player player)
        {
            base.Update(player);

            player._mMp += _mp;
        }

    }
}
