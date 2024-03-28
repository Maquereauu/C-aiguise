﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class House : Scene
    {
        public House() : base("House")
        {
            _isGameZone = true;
        }
        public override void Init()
        {
            _bitmap = new Bitmap("../../../Content/Map/maison.bmp");
            AddZone(new Zone("../../../Content/Map/maison.txt"));
            _map.SetCurrentZone();
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
        }
        public override void Update()
        {
            base.Update();
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



        public static void Swap()
        {
            int x = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item1;
            int y = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item2;
            if (EventManager._transform._mCoordinates.y() == 105/2 -y && EventManager._lastTouch == "down" )  // and last key = down
            {
                EventManager._transform.SetPos(142, 33 / 2 );
                SceneManager.SwitchScene("Game");
                //EventManager._transform.SetPos(100,192/2) ; //qu'est ce que quoi? 148,24 ça veut pas !! genre le x bouge pas mais mon y change mon x mais pas assez?
                //Console.SetCursorPosition(EventManager._transform._mCoordinates.x(), EventManager._transform._mCoordinates.y());
            }
        }
    }
}