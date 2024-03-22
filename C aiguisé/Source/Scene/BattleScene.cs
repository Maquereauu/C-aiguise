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
            Enemy enemy = new Enemy();
            Enemy enemy1 = new Enemy();
            List<Summon> summons = new List<Summon>();
            List<Enemy> enemies = new List<Enemy>() { enemy,enemy1};
            _battle = new Battle(EntityManager.players, summons,enemies);
            EventManager._downArrow += _battle.switchActionDown;
            EventManager._upArrow += _battle.switchActionUp;
            EventManager._enter += _battle.SelectMove;
            EventManager._menu += OpenMenu;
            _battle.Start();
        }
        public override void UnLoad()
        {
            base.UnLoad();
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
