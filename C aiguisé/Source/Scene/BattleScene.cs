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
        List<string> list = new List<string>() { "../../../Content/Role/Enemy1.txt", "../../../Content/Role/Enemy2.txt", "../../../Content/Role/Enemy3.txt" };
        List<string> list2 = new List<string>() {"Goomba","Alexandre","Goku" };
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
            Random random = new Random();
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < random.Next(3) + 2; i++)
            {
                int rand = random.Next(3);
                Enemy enemy = new Enemy(list[rand]);
                enemy._mName = list2[rand];
                enemies.Add(enemy);
            }
            _battle = new Battle(EntityManager.players,enemies);
            EventManager._downArrow += _battle.switchActionDown;
            EventManager._upArrow += _battle.switchActionUp;
            EventManager._rightArrow += _battle.switchActionRight;
            EventManager._leftArrow += _battle.switchActionLeft;
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
