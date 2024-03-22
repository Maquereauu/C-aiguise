using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace C_aiguisé
{
    public class MainMenu : Scene
    {

        private List<(int, int)> _hudPosList;
        private (int, int) _hudPos;
        private int _index;
        public MainMenu() : base("Main Menu")
        {
            for (int i = 0; i < 4; i++) 
            {
                _hudPosList = new List<(int, int)>() {(Console.WindowWidth / 2 - 13, Console.WindowHeight / 3),
                (Console.WindowWidth / 2 - 13, Console.WindowHeight / 3 + 2),
                (Console.WindowWidth / 2 - 13, Console.WindowHeight / 3 + 4),
                (Console.WindowWidth / 2 - 13, Console.WindowHeight / 3 + 6)};
            }
            _index = 0;
            _hudPos = (Console.WindowWidth / 2 - 13, Console.WindowHeight / 3);

        }
        public override void Init()
        {
            AddZone(new Zone("../../../Content/MainMenu.txt"));
            _map.SetCurrentZone();
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
            Console.Clear();
        }
        public override void Update()
        {
            base.Update();
            Console.SetCursorPosition(_hudPos.Item1, _hudPos.Item2);
            Console.Write("yo");
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            Console.CursorVisible = false;
            EventManager._menu += CloseMenu;
            EventManager._enter += Confirm;
            EventManager._upArrow += SwitchTop;
            EventManager._downArrow += SwitchBottom;
        }

        public override void UnLoad()
        {
            base.UnLoad();
            Console.CursorVisible = true;
            EventManager._menu -= CloseMenu;
            EventManager._enter -= Confirm;
            EventManager._upArrow -= SwitchTop;
            EventManager._downArrow -= SwitchBottom;
        }
        public static void CloseMenu()
        {
            SceneManager.SwitchScene();
        }

        public void Confirm()
        {
            switch (_index)
            {
                case 0:
                    break;
                case 1:
                    SceneManager.SwitchScene("Game");
                    break;
                case 2:
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SwitchTop()
        {
            _index = Utils.MathHelper.Modulo(_index - 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];
        }
        public void SwitchBottom()
        {
            _index = Utils.MathHelper.Modulo(_index + 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];
        }
    }
}