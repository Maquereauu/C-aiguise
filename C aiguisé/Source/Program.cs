// See https://aka.ms/new-console-template for more information

using C_aiguisé;
using Microsoft.VisualBasic;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        BattleScene scene = new BattleScene();
        SceneManager.AddScene(new MainMenu());
        SceneManager.AddScene(new Game());
        SceneManager.AddScene(scene);

        /*Cmd.test();*/

        Weapon weapon = new Weapon();
        
        Player player = new Player("noeil", weapon, new Tank());
        Enemy enemy = new Enemy();
        Enemy enemy1 = new Enemy();
        List<Player> playerlist = new List<Player>() { player };
        List<Enemy> enemylist = new List<Enemy>() { enemy, enemy1 };
        List<Summon> summonlist = new List<Summon>();
        Battle battle = new Battle(playerlist, summonlist, enemylist) ;

        SceneManager.Init();
        scene.SetBattle(battle);
        SceneManager.SwitchScene("BattleScene");
        SceneManager.Display();

        /*battle.Start();*/

        while (true)
        {
            EventManager.Update();
/*            SceneManager.PreUpdate();  
            SceneManager.Update();  
            SceneManager.PostUpdate();  */
        }
    }
}