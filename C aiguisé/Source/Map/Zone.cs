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
            Scene Currentscene = SceneManager.CurrentScene;
            Bitmap map = Currentscene.bitmap;
            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            Console.WriteLine(asciiArt);
            /*EventManager._transform.SetPos(0, 0);*/
            Console.SetCursorPosition(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y());
            /*EventManager.Movement(EventManager._transform2, 1, 0, "X");*/

           if(map == null )
            {
                return;
            }
            Color pix = map.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2);
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
        }

    }
}