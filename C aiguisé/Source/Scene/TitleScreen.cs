using C_aiguisé.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace C_aiguisé
{
    public class TitleScreen : Scene
    {//les players/inv/pos map/zone
        private List<(int, int)> _hudList = new List<(int, int)>() { (30, 10), (50, 10), (70, 10) };
        private (int, int) _test = (30,10);
        private int _index = 0;
        public TitleScreen() : base("Title Screen")
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
            Console.SetCursorPosition(_test.Item1, _test.Item2);
            Console.Write("yo");
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            Console.CursorVisible = false;
            EventManager._enter += Play;
            EventManager._leftArrow += SwitchLeft;
            EventManager._rightArrow += SwitchRight;
        }

        public override void UnLoad()
        {
            base.UnLoad();
            Console.CursorVisible = true;
            EventManager._enter -= Play;
            EventManager._leftArrow -= SwitchLeft;
            EventManager._rightArrow -= SwitchRight;
        }
        public void Play()
        {
            SceneManager.SwitchScene("Game");
        }
        public void SwitchLeft()
        {
            _index = MathHelper.Mod(_index - 1,_hudList.Count);
            _test = _hudList[_index];
        }
        public void SwitchRight()
        {
            _index = MathHelper.Mod(_index + 1, _hudList.Count);
            _test = _hudList[_index];
        }
    }
}