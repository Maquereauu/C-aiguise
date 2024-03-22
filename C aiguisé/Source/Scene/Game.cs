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
            AddZone(new Zone("../../../Content/Map/nahidwin.txt"));
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
        }

        public static void OpenMenu()
        {
            SceneManager.SwitchScene("Main Menu");
        }

        public static void DetectBattle()
        {
            Bitmap b = new Bitmap("../../../Content/Map/map.bmp");
            Color pix = b.GetPixel(0, 0);
            for (int k = 0; k < 190; k++)
            {
                for (int l = 0; l < 108; l++)
                {
                    Color grass = b.GetPixel(k, l);
                    if (grass == pix)
                    {
                        int test = EventManager._transform.GetCoordinates().x();
                        int testy = EventManager._transform.GetCoordinates().y();
                        if ( test== k && testy == l)
                        {
                            SceneManager.SwitchScene("BattleScene");
                        }
                    }
                }
            }

 
        }
    }
}