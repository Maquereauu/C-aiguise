﻿using System;
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
            _bitmap = new Bitmap("../../../Content/Map/map.bmp");
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
            //DetectBattle();
            Swap();
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

        public void DetectBattle()
        {
            
            //byte a = 255;
            byte r = 34;
            byte g = 177;
            byte b = 76;
            //Color pix = { 34, 177, 76, 255 };
            for (int k = 0; k < 192; k++)
            {
                for (int l = 0; l < 108; l++)
                {
                   
                    Color grass = _bitmap.GetPixel(k,l);

                    

                    if (grass.R == r && grass.G == g && grass.B == b)
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


        public override void Swap()
        {
            if (EventManager._transform.GetCoordinates().x() >= 148 && EventManager._transform.GetCoordinates().x() <= 155 && EventManager._transform.GetCoordinates().y() == 24/2 && EventManager._lastTouch == "up")
            {
                SceneManager.SwitchScene("House");
            }
            if (EventManager._transform.GetCoordinates().x() >= 72 && EventManager._transform.GetCoordinates().x() <= 115 && EventManager._transform.GetCoordinates().y() == 0 && EventManager._lastTouch == "up")
            {
                SceneManager.SwitchScene("ZoneNord");
            }
            if (EventManager._transform.GetCoordinates().x() == 0 && EventManager._transform.GetCoordinates().y() >= 35/2 && EventManager._lastTouch == "left")
            {
                SceneManager.SwitchScene("ZoneNord");
            }
            if (EventManager._transform.GetCoordinates().x() <= 116 && EventManager._transform.GetCoordinates().y() == 105/2 && EventManager._lastTouch == "down")
            {
                SceneManager.SwitchScene("ZoneNord");
            }
            if (EventManager._transform.GetCoordinates().x() >= 189 && EventManager._transform.GetCoordinates().y() >= 34 / 2 && EventManager._transform.GetCoordinates().y() <= 68 / 2 &&EventManager._lastTouch == "right")
            {
                SceneManager.SwitchScene("ZoneNord");
            }
        }
    }
}