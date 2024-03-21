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


            /*            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
                        var characterPosition = EventManager._transform.GetCoordinates();

                        for (int i = 0; i < asciiArt.Length; i++)
                        {
                            int xPosition = i % Console.BufferWidth;
                            int yPosition = i / Console.BufferWidth;

                            if (xPosition == characterPosition.x() && yPosition == characterPosition.y())
                            {
                                continue; // Skip drawing over the character position
                            }

                            Console.Write(asciiArt[i]);
                        }*/
            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            Console.WriteLine(asciiArt);
            /*EventManager._transform.SetPos(0, 0);*/
            Console.SetCursorPosition(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y());

            Console.Write("P");
            Console.SetCursorPosition(0, 0);
            /*for (int i = 0; i < asciiArt.Length; i++)
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
            }*/
            /*string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            for (int i = 0; i < asciiArt.Length; i++)
            {
                int x = i % Console.BufferWidth;
                int y = i / Console.BufferWidth;

                if (x != EventManager._transform.GetCoordinates().x() || y != EventManager._transform.GetCoordinates().y())
                {
                    Console.Write(asciiArt[i]);
                }
                else
                {
                    (int left, int top) = (Console.CursorLeft, Console.CursorTop);
                    Console.SetCursorPosition(left + 1, top);
                }
            }
            */
        }

    }
}