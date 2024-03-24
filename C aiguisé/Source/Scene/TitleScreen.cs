﻿using C_aiguisé;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace C_aiguisé
{
    public class TitleScreen : Scene
    {
        private List<(int, int)> _hudList;
        private (int, int) _test;
        private int _index;
        private List<string> _text;
        void DrawBox(string text,int i)
        {

            int boxWidth = text.Length + 4; // Adjusting box width based on text length
            int boxHeight = 3;

            // Top line of the box
            Console.Write("╔" + new string('═', boxWidth ) + "╗");
            Console.SetCursorPosition(_hudList[i].Item1, _hudList[i].Item2 + 1);
            // Middle lines with text
            Console.Write("║" + new string(' ', boxWidth) + "║");
            Console.SetCursorPosition(_hudList[i].Item1, _hudList[i].Item2 + 2);
            Console.Write("║  " + text + "  ║");
            Console.SetCursorPosition(_hudList[i].Item1, _hudList[i].Item2 + 3);
            Console.Write("║" + new string(' ', boxWidth ) + "║");
            Console.SetCursorPosition(_hudList[i].Item1, _hudList[i].Item2 + 4);

            // Bottom line of the box
            Console.Write("╚" + new string('═', boxWidth) + "╝");
        }
        public TitleScreen() : base("Title Screen")
        {
            _hudList = new List<(int, int)>() { (30, 40), (90, 40), (160, 40) }; // list of pos (x, y)
            _test = (30, 40);
            _index = 0;
            _text = new List<string>() {"Play","Load Game","Quit" };
        }
        public override void Init()
        {
            AddZone(new Zone("../../../Content/Map/titleScreen.txt"));
            _map.SetCurrentZone();
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
        }
        public override void Update()
        {
            base.Update();
            for (int i = 0; i < _hudList.Count; i++)
            {
                Console.SetCursorPosition(_hudList[i].Item1, _hudList[i].Item2);
                DrawBox(_text[i],i);
            }
            Console.SetCursorPosition(_test.Item1 + 1, _test.Item2 + 2);
            Console.Write(">");
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            Console.CursorVisible = false;
            EventManager._enter += Confirm;
            EventManager._leftArrow += SwitchLeft;
            EventManager._rightArrow += SwitchRight;
        }

        public override void UnLoad()
        {
            base.UnLoad();
            Console.CursorVisible = true;
            EventManager._enter -= Confirm;
            EventManager._leftArrow -= SwitchLeft;
            EventManager._rightArrow -= SwitchRight;
        }
        public void Confirm()
        {
            switch (_index)
            {
                case 0:
                    SceneManager.SwitchScene("Game");
                    break;
                case 1:
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public void SwitchLeft()
        {
            _index = Utils.MathHelper.Modulo(_index - 1,_hudList.Count);
            _test = _hudList[_index];
        }
        public void SwitchRight()
        {
            _index = Utils.MathHelper.Modulo(_index + 1, _hudList.Count);
            _test = _hudList[_index];
        }
    }
}