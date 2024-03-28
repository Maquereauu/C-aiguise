using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class Potion : Consumable
    {
        float _heal;
        public Potion(int heal) : base("Potion")
        {
            _heal = heal;
        }

        public override void Update(Player player)
        {
            base.Update(player);
            player._mHp += _heal;
        }
    }
}
