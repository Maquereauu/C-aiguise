using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{ 
    class Ether : Item
    {
        int _mp;
        public Ether(int mp) : base ("Ether", false)
        {
            _mp = mp;
        }

        public override void Update(Player player)
        {
            base.Update(player);

            player.HealMp(_mp);
        }

    }
}
