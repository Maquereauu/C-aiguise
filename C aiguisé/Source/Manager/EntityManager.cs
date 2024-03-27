using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public static class EntityManager
    {
        public static List<Player> players = new List<Player>();

        public static void CreatePlayer(string name, Weapon weapon, Role role)
        {
            Player player = new Player(name, weapon, role);
            players.Add(player);
        }

        public static void CreatePlayer(string name, float hp, float hpMax, float mp, float mpMax, int level, float exp,
            int critChance, int critDamage, int dodgeChance, string type, float speed, bool isDead,
            List<AttackMove> attackMove, int summonBar, Weapon weapon, Role role)
        {
            Player player = new Player(name, hp, hpMax, mp, mpMax, level, exp,
            critChance, critDamage, dodgeChance, type, speed, isDead,
            attackMove, summonBar, weapon, role);

            players.Add(player);
        }
    }
}