// See https://aka.ms/new-console-template for more information

using C_aiguisé;
using Microsoft.VisualBasic;

public class Program
{
    public static void Main(string[] args)
    {
        /*Cmd.test();*/
        EventManager._rightArrow += EventManager.MoveRight;
        EventManager._leftArrow += EventManager.MoveLeft;
        EventManager._downArrow += EventManager.MoveDown;
        EventManager._upArrow += EventManager.MoveUp;

        while (true)
        {
            EventManager.Update();
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