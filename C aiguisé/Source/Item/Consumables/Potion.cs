using C_aiguisé;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    public class Potion : Item
    {
        int _heal;
        public Potion(int heal) : base("Potion",false)
        {
            _heal = heal;
        }

        public override void Update(Player player)
        {
            base.Update(player);
            player.Heal(_heal);
        }
    }
}
