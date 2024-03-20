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
            AddZone(new Zone("../../../Content/Map/nahidwin2.txt"));
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
            EventManager._rightArrow += EventManager.MoveRight;
            EventManager._leftArrow += EventManager.MoveLeft;
            EventManager._downArrow += EventManager.MoveDown;
            EventManager._upArrow += EventManager.MoveUp;
            EventManager._menu += OpenMenu;
        }
        public override void UnLoad()
        {
            EventManager._rightArrow -= EventManager.MoveRight;
            EventManager._leftArrow -= EventManager.MoveLeft;
            EventManager._downArrow -= EventManager.MoveDown;
            EventManager._upArrow -= EventManager.MoveUp;
        }

        public static void OpenMenu()
        {
            SceneManager.SwitchScene("Main Menu");
        }
    }
}