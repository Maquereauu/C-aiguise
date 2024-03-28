using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class PlayerStatsScene : Scene
    {
        Player _player;
        public PlayerStatsScene(Player player) : base(player._mName + "StatsScene")
        {
            _player = player;
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
            Console.Write(_player._mAttackMoves);
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            EventManager._menu += Exit;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            EventManager._menu -= Exit;
        }

        public void Exit()
        {
            SceneManager.SwitchScene(SceneManager._previousScene.GetName());
        }
    }
}
