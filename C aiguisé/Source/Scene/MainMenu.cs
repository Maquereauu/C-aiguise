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
        private List<string> _hudNameList;
        private (int, int) _hudPos;
        private int _index;
        public MainMenu() : base("Main Menu")
        {
            _hudPosList = new List<(int, int)>() {((Console.WindowWidth / 2) - (14 / 2), (Console.WindowHeight / 2) - (7 / 2) - 4),
            ((Console.WindowWidth / 2) - (14 / 2), (Console.WindowHeight / 2) - (7 / 2) - 2),
            ((Console.WindowWidth / 2) - (14 / 2), (Console.WindowHeight / 2) - (7 / 2)),
            ((Console.WindowWidth / 2) - (14 / 2), (Console.WindowHeight / 2) - (7 / 2) + 2)};

            _hudNameList = new List<string>() { "    Option   ", "Retour au jeu", " Sauvegarder" , "   Quitter   "};
            _index = 0;
            _hudPos = (_hudPosList[0].Item1, _hudPosList[0].Item2);

        }
        public override void Init()
        {

        }
        public override void PreUpdate()
        {
            base.PreUpdate();
            Console.Clear();
        }
        public override void Update()
        {
            for (int i = 0; i < _hudPosList.Count; i++)
            {
                Console.SetCursorPosition(_hudPosList[i].Item1, _hudPosList[i].Item2);
                Console.Write(_hudNameList[i]);
            }
            Console.SetCursorPosition(_hudPos.Item1 - 10, _hudPos.Item2);
            Console.Write(">");
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
            _hudPos = (_hudPosList[0].Item1, _hudPosList[0].Item2);
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