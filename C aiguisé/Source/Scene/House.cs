using System;
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
        }
        public override void Init()
        {
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
            if (EventManager._transform.GetCoordinates().x() == 148)
            {
                SceneManager.SwitchScene("House");
            }
        }
    }
}