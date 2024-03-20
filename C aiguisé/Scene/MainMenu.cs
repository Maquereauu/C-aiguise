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
            Console.WriteLine(_map.GetCurrentZone());
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
            EventManager._rightArrow += EventManager.Menu;
        }

        public override void UnLoad()
        {
            EventManager._rightArrow -= EventManager.Menu;
        }
    }
}