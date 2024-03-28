using System;
using System.Collections.Generic;
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
            Console.SetCursorPosition(EventManager._transform._mCoordinates.x(), EventManager._transform._mCoordinates.y());
            /*EventManager.Movement(EventManager._transform2, 1, 0, "X");*/
            Console.Write("P");
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
    }
}