// See https://aka.ms/new-console-template for more information

using C_aiguisé;
using Microsoft.VisualBasic;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SceneManager.AddScene(new MainMenu());
        SceneManager.AddScene(new Game());

        SceneManager.Init();

        SceneManager.SwitchScene("Game");
        SceneManager.Display();
        /*Cmd.test();*/

        Weapon sword = new Weapon("Sword");
        Weapon knife = new Weapon("Knife");
        Player player = new Player("noeil", sword, "mage");
        Enemy enemy = new Enemy();
        Enemy enemy1 = new Enemy();
        List<Player> playerlist = new List<Player>() { player };
        List<Enemy> enemylist = new List<Enemy>() { enemy, enemy1 };
        List<Summon> summonlist = new List<Summon>();
        Battle battle = new Battle(playerlist, summonlist, enemylist) ;

        /*battle.Start();

          battle.Update();*/

        Bag bag = new Bag();

        bag.AddItem(new List<Item>() { sword, knife }, new List<int>() { 2, 3 });

        bag.RemoveItem(new List<Item>() { sword, knife }, new List<int>() { 1, 4 });

        while (true)
        {
            /*SceneManager.PreUpdate();  
            SceneManager.Update();  
            SceneManager.PostUpdate();  */
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