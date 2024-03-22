using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public static class EntityManager
    {
        public static List<Player> players = new List<Player>();

        public static void CreatePlayer()
        {
            Player player = new Player("noeil", new Weapon("Sword"),new Tank());
            players.Add(player);
        }
    }
}