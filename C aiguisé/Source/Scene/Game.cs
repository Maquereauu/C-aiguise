using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Game : Scene
    {
        public Game() : base("Game")
        {
        }
        public override void Init()
        {
            AddZone(new Zone("../../../Content/Map/map.txt"));
            _map.SetCurrentZone();
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
        }
        public override void Update()
        {
            base.Update();
            DetectBattle();
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            Console.CursorVisible = false;
            EventManager._rightArrow += EventManager.MoveRight;
            EventManager._leftArrow += EventManager.MoveLeft;
            EventManager._downArrow += EventManager.MoveDown;
            EventManager._upArrow += EventManager.MoveUp;
            EventManager._menu += OpenMenu;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            Console.CursorVisible = true;
            EventManager._rightArrow -= EventManager.MoveRight;
            EventManager._leftArrow -= EventManager.MoveLeft;
            EventManager._downArrow -= EventManager.MoveDown;
            EventManager._upArrow -= EventManager.MoveUp;
            EventManager._menu -= OpenMenu;
        }

        public static void DetectBattle()
        {
            Bitmap b = new Bitmap("../../../Content/Map/map.bmp");
            Color pix = b.GetPixel(0, 0);
            for (int k = 0; k < 192; k++)
            {
                for (int l = 0; l < 108; l++)
                {
                    Color grass = b.GetPixel(k,l);

                    

                    if (grass == pix)
                    {
                        if (EventManager._transform.GetCoordinates().x() == k && EventManager._transform.GetCoordinates().y() == l / 2)
                        {
                            //Console.WriteLine(grass);
                            Random rnd = new Random();
                            int battleRate = rnd.Next(10);
                            if(battleRate == 0)
                            {
                                SceneManager.SwitchScene("BattleScene");
                            }
                        }
                            
                    }
                }
            }
        }
    }
}