using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace C_aiguisé
{
    public static class Cmd
    {
    public static void test()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            /*Console.SetWindowSize(1920, 1080);*/
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            string asciiArt = File.ReadAllText("nahidwin.txt");

            // Print the ASCII art to the console
            Console.WriteLine(asciiArt);
            /*Console.Write("Hello, World!");*/
            Console.Read();
            /*Console.Beep();*/
        }
    }
}