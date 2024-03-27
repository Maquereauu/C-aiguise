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

        SceneManager.AddScene(new House());
        SceneManager.AddScene(new ZoneNord());

        SceneManager.AddScene(new Game());
        SceneManager.AddScene(scene);

        Tank tank = new Tank();
        Knight knight = new Knight();
        Weapon sword = new Weapon("Sword");
        Weapon knife = new Weapon("Knife");
        EntityManager.CreatePlayer("Jean", sword, tank);
        EntityManager.CreatePlayer("Pierre", knife, knight);

        Bag.AddItem(new List<Item>() { sword, knife }, new List<int>() { 2, 3 });

        SceneManager.Init();
/*        scene.SetBattle(battle);*/
        SceneManager.SwitchScene("TitleScreen");

        scene.SetBattle(battle);
        SceneManager.SwitchScene("Game");
        /*SceneManager.Display();*/

        /*battle.Start();*/

        /*        Save save = new Save();
                save.LoadGame("../../../Content/Saves/Save1.json");*/

        //Console.Write(File.ReadAllText("../../../Content/Role/Player.txt"));
        FileReader.GetSizeFromFile("../../../Content/Role/Player.txt");

        while (true)
        {
            SceneManager.PreUpdate();
            SceneManager.Update();
            SceneManager.PostUpdate();
        }
    }
}