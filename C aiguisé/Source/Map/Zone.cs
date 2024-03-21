using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Zone
    {
        private string _sprit;

        public Zone (string sprit)
        {
            _sprit = sprit;
        }

        public void Display()
        {



            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            for(int i = 0; i < asciiArt.Length; i++)
            {
                if ((EventManager._transform.GetCoordinates().x() != i % Console.BufferWidth) && (EventManager._transform.GetCoordinates().y() != i / Console.BufferWidth))
                { 
                    Console.Write(asciiArt[i]); 
                }
                else
                {
                    
                    (int, int) pos = Console.GetCursorPosition();
                    if (Console.GetCursorPosition().Left % (Console.BufferWidth - 1) == 0 && Console.GetCursorPosition().Left != 0)
                    {
                        Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
                    }
                    else  
                    {
                        Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                    }
                }
            }
        }

    }
}