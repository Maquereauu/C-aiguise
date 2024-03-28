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
        SceneManager.AddScene(new GameOver());
        SceneManager.AddScene(new QuestScene());

        SceneManager.AddScene(new Game());
        SceneManager.AddScene(new House());
        SceneManager.AddScene(new ZoneNord());

        SceneManager.AddScene(new BagScene());
        SceneManager.AddScene(scene);


        SceneManager.Init();
        SceneManager.SwitchScene("TitleScreen");

        QuestManager.SetQuest(new Quest("Vous devez tuer 10 monstres", 10,0, false, 1000, false));


        while (true)
        {
            SceneManager.PreUpdate();
            SceneManager.Update();
            SceneManager.PostUpdate();
        }
    }
}