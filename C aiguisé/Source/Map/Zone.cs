using System;
using System.Collections.Generic;
using System.Drawing;
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
                                continue; 
                            }

                            Console.Write(asciiArt[i]);
                        }*/
            //SceneManager.CurrentScene;
            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            Console.WriteLine(asciiArt);
            /*EventManager._transform.SetPos(0, 0);*/
            Console.SetCursorPosition(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y());
            /*EventManager.Movement(EventManager._transform2, 1, 0, "X");*/

            Bitmap b = new Bitmap("../../../Content/Map/map.bmp"); // récupérer la zone actuelle
            Color pix = b.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2);
            byte pixR = pix.R;
            
            byte pixG = pix.G;
          
            byte pixB = pix.B;
            
            if(pixR ==0 && pixG ==0 && pixB == 0)
            {
                //EventManager._transform.SetPos(EventManager._transform.GetCoordinates().x()-1, EventManager._transform.GetCoordinates().y() * 2);
                Console.Write("\x1b[37;40mP");
            }
            else
            {
                Console.Write("\x1b[30;48;2;" + pixR.ToString() + ";" + pixG.ToString() + ";" + pixB.ToString() + "mP");
            }
            //Console.WriteLine(pixB);
            /*            Console.SetCursorPosition(EventManager._transform2.GetCoordinates().x(), EventManager._transform2.GetCoordinates().y());
                        Console.Write("X");*//*
                        Console.SetCursorPosition(0, 0);*/
            /*            for (int i = 0; i < asciiArt.Length; i++)
                        {
                            if ((EventManager._transform.GetCoordinates().x() != i % Console.BufferWidth) && (EventManager._transform.GetCoordinates().y() != i / Console.BufferWidth))
                            {
                                Console.Write(asciiArt[i]);
                            }
                            else
                            {

                                Console.Write("P");
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