// See https://aka.ms/new-console-template for more information

using C_aiguisé;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Text;

public class Program
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    const int SW_MAXIMIZE = 3;
    public static void Main(string[] args)
    {
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, SW_MAXIMIZE);
        Console.OutputEncoding = Encoding.UTF8;

        BattleScene scene = new BattleScene();
        SceneManager.AddScene(new MainMenu());
        SceneManager.AddScene(new TitleScreen());
        SceneManager.AddScene(new Game());
        SceneManager.AddScene(scene);

        /*Cmd.test();*/

        Weapon sword = new Weapon("Sword");
        Weapon knife = new Weapon("Knife");
        EntityManager.CreatePlayer();
       /* Player player = new Player("noeil", sword, new Tank());*/
/*        Enemy enemy = new Enemy();
        Enemy enemy1 = new Enemy();
        List<Player> playerlist = new List<Player>() { player };
        List<Enemy> enemylist = new List<Enemy>() { enemy, enemy1 };
        List<Summon> summonlist = new List<Summon>();
        Battle battle = new Battle(playerlist, summonlist, enemylist) ;*/

        SceneManager.Init();
/*        scene.SetBattle(battle);*/
        //SceneManager.SwitchScene("Title Screen");
        SceneManager.SwitchScene("BattleScene");
        /*SceneManager.Display();*/

        /*battle.Start();*/

        /*        Bag bag = new Bag();

                bag.AddItem(new List<Item>() { sword, knife }, new List<int>() { 2, 3 });

                bag.RemoveItem(new List<Item>() { sword, knife }, new List<int>() { 1, 4 });*/
     /*   Save save = new Save();
        save._mPlayer = new List<Character>() { EntityManager.players[0] };
        save._mCurrentZone = "Main Menu";
        save._mItem.Add(knife);
        save._mItem.Add(sword);
        save._mItemNumber.Add(1);
        save._mItemNumber.Add(1);

        save.SaveGame("../../../Content/Saves/Save1.json");
        save.LoadGame("../../../Content/Saves/Save1.json");*/
        while (true)
        {
            SceneManager.PreUpdate();
            SceneManager.Update();
            SceneManager.PostUpdate();
        }
    }
}