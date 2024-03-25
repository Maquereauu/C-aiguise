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

        Tank role = new Tank();
        Weapon sword = new Weapon("Sword");
        Weapon knife = new Weapon("Knife");
        EntityManager.CreatePlayer("Jean", sword, role);

        SceneManager.Init();
/*        scene.SetBattle(battle);*/
        SceneManager.SwitchScene("TitleScreen");
        /*SceneManager.Display();*/

        /*battle.Start();*/

        /*        Bag bag = new Bag();

                bag.AddItem(new List<Item>() { sword, knife }, new List<int>() { 2, 3 });

                bag.RemoveItem(new List<Item>() { sword, knife }, new List<int>() { 1, 4 });*/
        Save save = new Save();
        save._mPlayer = new List<Player>() { EntityManager.players[0] };
        save._mCurrentZone = "MainMenu";
        save._mItem.Add(knife);
        save._mItem.Add(sword);
        save._mItemNumber.Add(1);
        save._mItemNumber.Add(1);

        /*save.SaveGame("../../../Content/Saves/Save1.json");*/
        save.LoadGame("../../../Content/Saves/Save1.json");
        while (true)
        {
            SceneManager.PreUpdate();
            SceneManager.Update();
            SceneManager.PostUpdate();
        }
    }
}