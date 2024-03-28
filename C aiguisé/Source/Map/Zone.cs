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
            Scene Currentscene = SceneManager._mCurrentScene;
            Bitmap map = Currentscene.bitmap;
            string asciiArt = File.ReadAllText(_sprit).Replace("\\x1b", "\x1b");
            Console.WriteLine(asciiArt);
            /*EventManager._transform.SetPos(0, 0);*/
            int x = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item1;
            int y = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item2;
            /*EventManager.Movement(EventManager._transform2, 1, 0, "X");*/

           if(map == null )
            {
                return;
            }
            string[] sprite = File.ReadAllText(EntityManager.players[1]._mSprite).Split("\r\n") ;

            
            
            
            //if(pixR ==0 && pixG ==0 && pixB == 0)
            //{
            //    //EventManager._transform.SetPos(EventManager._transform._mCoordinates.x()-1, EventManager._transform._mCoordinates.y() * 2);
            //    Console.Write("\x1b[37;40m" + sprite);
            //}
            //else
            for(int i =0; i <y; i++) {
                Console.SetCursorPosition(EventManager._transform._mCoordinates.x(), EventManager._transform._mCoordinates.y() + i);

                for (int j = 0; j < x; j++)
                {
                    Color pix = map.GetPixel(EventManager._transform._mCoordinates.x()+j, EventManager._transform._mCoordinates.y()*2 +i*2);
                    byte pixR = pix.R;
                    byte pixG = pix.G;
                    byte pixB = pix.B;
                    Console.Write("\x1b[30;48;2;" + pixR.ToString() + ";" + pixG.ToString() + ";" + pixB.ToString() + "m" + sprite[i][j]);
                }
                
            }
            
        }

    }
}