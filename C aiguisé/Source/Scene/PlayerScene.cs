using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class PlayerScene : Scene
    {
        public PlayerScene() : base("PlayerScene")
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
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < EntityManager.players.Count; i++)
            {
                Console.Write(EntityManager.players[i]._mName + "\n");
            }
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
