using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    public class BattleScene : Scene
    {
        public BattleScene() : base("BattleScene")
        {
        }
        public override void Init()
        {

        }
        public override void PreUpdate()
        {
        }
        public override void Update()
        {
        }

        public override void PostUpdate()
        {
        }
        public override void LoadScene()
        {
            Console.CursorVisible = false;
            EventManager._downArrow += _battle.switchActionDown;
            EventManager._upArrow += _battle.switchActionUp;
            EventManager._enter += _battle.SelectMove;
            EventManager._menu += OpenMenu;
            _battle.Start();
        }
        public override void UnLoad()
        {
            Console.CursorVisible = true;
            EventManager._downArrow -= _battle.switchActionDown;
            EventManager._upArrow -= _battle.switchActionUp;
            EventManager._menu -= OpenMenu;
        }

        public override void SetBattle(Battle battle)
        {
            _battle = battle;
        }
        
    }
}
