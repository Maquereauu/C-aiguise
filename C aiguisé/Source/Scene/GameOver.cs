using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class GameOver : Scene
    {
        private int _index;
        private List<(int, int)> _hudPosList;
        private List<string> _hudNameList;
        private (int, int) _hudPos;
        public GameOver () : base ("GameOver")
        {
            _hudNameList = new List<string>() { " Charger une sauvegarde ", " Quitter "};
            _hudPosList = new List<(int, int)>() { (60, 25), (100, 25)};
            _hudPos = ((_hudPosList[0].Item1, _hudPosList[0].Item2));
        }

        public override void Init()
        {
            AddZone(new Zone("../../../Content/Map/GameOver.txt"));
            _map.SetCurrentZone();
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
        }
        public override void Update()
        {
            base.Update();
            Console.SetCursorPosition(_hudPos.Item1, _hudPos.Item2);
            Console.Write(">");

            for (int i = 0; i < _hudNameList.Count; i++)
            {
                Console.SetCursorPosition(_hudPosList[i].Item1 + 1, _hudPosList[i].Item2);
                Console.Write(_hudNameList[i] + "\n\n");
            }

        }

        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            EventManager._menu += Exit;
            EventManager._leftArrow += SwitLeft;
            EventManager._rightArrow += SwitchRight;
            EventManager._enter += Confirm;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            _index = 0;
            EventManager._menu -= Exit;
            EventManager._leftArrow -= SwitLeft;
            EventManager._rightArrow -= SwitchRight;
            EventManager._enter -= Confirm;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void Confirm()
        {
             switch (_index)
            {
                case 0:
                    Save save = new Save();
                    save.LoadGame("../../../Content/Saves/Save1.json");
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }
            _hudPos = (_hudPosList[0].Item1, _hudPosList[0].Item2);
        }
        public void SwitLeft()
        {
            _index = Utils.MathHelper.Modulo(_index - 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];
        }
        public void SwitchRight()
        {
            _index = Utils.MathHelper.Modulo(_index + 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];

        }
    }
}
