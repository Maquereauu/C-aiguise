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
            _isGameZone = true;
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
            Console.SetCursorPosition(EventManager._transform._mCoordinates.x(), EventManager._transform._mCoordinates.y());

            /*EventManager.Movement(EventManager._transform2, 1, 0, "X");*/
            
            //Console.Write("P");
           DetectBattle();
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
            EventManager._tab += ShowBag;
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
            EventManager._tab -= ShowBag;
        }

        public void ShowBag()
        {
            SceneManager.SwitchScene("BagScene");
        }

        public void DetectBattle()
        {
            int x = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item1;
            int y = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item2;

            //byte a = 255;
            byte r = 34;
            byte g = 177;
            byte b = 76;
            //Color pix = { 34, 177, 76, 255 };

            for (int k = 0; k < 192; k++)
            {
                for (int l = 0; l < 108; l++)
                {

                    Color grass = _bitmap.GetPixel(k, l);
                    if (grass.R == r && grass.G == g && grass.B == b)
                    {
                        if (EntityManager.players[0]._mTranform._mCoordinates.x() == k && EntityManager.players[0]._mTranform._mCoordinates.y() == l / 2)
                        {
                            //Console.WriteLine(grass);
                            Random rnd = new Random();
                            int battleRate = rnd.Next(50);
                            if (battleRate == 0)
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
            int x = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item1;
            int y = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item2;
            if (EntityManager.players[0]._mTranform._mCoordinates.x() >= 140 && EntityManager.players[0]._mTranform._mCoordinates.x() <= 165 && EntityManager.players[0]._mTranform._mCoordinates.y() == 33/2  && EventManager._lastTouch == "up")
            {
                EntityManager.players[0]._mTranform.SetPos(192/2, 107 / 2 - y);
                SceneManager.SwitchScene("House");
            }


            if (EntityManager.players[0]._mTranform._mCoordinates.x() >= 72 && EntityManager.players[0]._mTranform._mCoordinates.x() <= 115 && EntityManager.players[0]._mTranform._mCoordinates.y() == 0 && EventManager._lastTouch == "up")
            {
                EntityManager.players[0]._mTranform.SetPos(EntityManager.players[0]._mTranform._mCoordinates.x(), 107 / 2 - y);
                //Console.SetCursorPosition(EventManager._transform._mCoordinates.x(), EventManager._transform._mCoordinates.y());
                SceneManager.SwitchScene("ZoneNord");

               
            }
            if (EntityManager.players[0]._mTranform._mCoordinates.x() == 0 && EntityManager.players[0]._mTranform._mCoordinates.y() >= 35/2 && EventManager._lastTouch == "left")
            {
                EntityManager.players[0]._mTranform.SetPos(190 - x, EntityManager.players[0]._mTranform._mCoordinates.y());
                SceneManager.SwitchScene("ZoneNord");
            }
            if (EntityManager.players[0]._mTranform._mCoordinates.x() <= 116 && EntityManager.players[0]._mTranform._mCoordinates.y() == 105 / 2 - y && EventManager._lastTouch == "down")
            {
                EntityManager.players[0]._mTranform.SetPos(EntityManager.players[0]._mTranform._mCoordinates.x(), 0);
                SceneManager.SwitchScene("ZoneNord");
            }
            if (EntityManager.players[0]._mTranform._mCoordinates.x() >= 189 - x && EntityManager.players[0]._mTranform._mCoordinates.y() >= 34 / 2 && EntityManager.players[0]._mTranform._mCoordinates.y() <= 68 / 2 &&EventManager._lastTouch == "right")
            {
                EntityManager.players[0]._mTranform.SetPos(0, EntityManager.players[0]._mTranform._mCoordinates.y());
                SceneManager.SwitchScene("ZoneNord");
            }
        }
    }
}