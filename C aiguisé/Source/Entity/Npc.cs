using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace C_aiguisé
{
    public class Npc
    {
        private string _name;
        private string _sprite;//?
        public Npc() {
            _sprite = "../../../Content/Role/npc.txt";
        }

        public void Dialog1()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 19);
            Console.Write("╔" + new string('═', 40) + "╗");
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(40, 20 + i);
                Console.Write("║" + new string(' ', 40) + "║");
            }
            Console.SetCursorPosition(40, 30);
            Console.Write("╚" + new string('═', 40) + "╝");
            Console.SetCursorPosition(41, 20);
            Console.Write("Salut");
        }

        public void Dialog2()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 19);
            Console.Write("╔" + new string('═', 40) + "╗");
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(40, 20 + i);
                Console.Write("║" + new string(' ', 40) + "║");
            }
            Console.SetCursorPosition(40, 30);
            Console.Write("╚" + new string('═', 40) + "╝");
            Console.SetCursorPosition(41, 20);
            Console.Write("C'est Johnny");
        }


        public void Display()
        {
            Console.SetCursorPosition(130, 5);
            string spriteText = File.ReadAllText(_sprite).Replace("\\x1b", "\x1b");
            string[] lines = spriteText.Split('\n');
            foreach (string line in lines)
            {
                Console.Write(line);
                Console.SetCursorPosition(130, Console.CursorTop + 1);
            }
        }
    }
}