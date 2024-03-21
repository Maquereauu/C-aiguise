using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace C_aiguisé
{
    public class MainMenu : Scene
    {
        public MainMenu() : base("Main Menu")
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
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            EventManager._menu += CloseMenu;
        }

        public override void UnLoad()
        {
            EventManager._menu += CloseMenu;
        }
        public static void CloseMenu()
        {
            SceneManager.SwitchScene("Game");
        }
    }
}