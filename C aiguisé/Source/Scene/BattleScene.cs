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
            EventManager._downArrow += _battle.switchActionDown;
            EventManager._upArrow += _battle.switchActionUp;
            EventManager._enter += _battle.SelectMove;
            _battle.Start();
        }
        public override void UnLoad()
        {
            EventManager._downArrow -= _battle.switchActionDown;
            EventManager._upArrow -= _battle.switchActionUp;
        }

        public override void SetBattle(Battle battle)
        {
            _battle = battle;
        }
        
    }
}
