// See https://aka.ms/new-console-template for more information

using C_aiguisé;
using Microsoft.VisualBasic;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Map map = new Map();
        Zone zone1 = new Zone("../../../Content/Map/nahidwin.txt");
        Zone zone2 = new Zone("../../../Content/Map/nahidwin2.txt");

        map.SetCurrentZone(zone1);
        /*Cmd.test();*/

        EventManager._rightArrow += EventManager.MoveRight;
        EventManager._leftArrow += EventManager.MoveLeft;
        EventManager._downArrow += EventManager.MoveDown;
        EventManager._upArrow += EventManager.MoveUp;

        map.Update();

        Weapon weapon = new Weapon();
        Player player = new Player("noeil", weapon, "mage");
        Enemy enemy = new Enemy();
        List<Player> playerlist = new List<Player>() { player };
        List<Enemy> enemylist = new List<Enemy>() { enemy };
        List<Summon> summonlist = new List<Summon>();
        Battle battle = new Battle(playerlist, summonlist, enemylist) ;
        battle.Start();

        while (true)
        {
            EventManager.Update();
           /* battle.Update();*/
        }
        /*        Console.OutputEncoding = System.Text.Encoding.UTF8;
                for (var i = 0; i <= 1000; i++)
                {
                    Console.Write(Strings.ChrW(i));
                    if (i % 50 == 0)
                    { // break every 50 chars
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();*/
    }
}