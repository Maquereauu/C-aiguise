using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class QuestScene : Scene
    {
        public QuestScene() : base("QuestScene")
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
            Display();
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
            SceneManager.SwitchScene(SceneManager._mPreviousScene.GetName());
        }

        public void Display()
        {
            Console.SetCursorPosition(3, Console.CursorTop + 3);
            Console.Write("Description : " + QuestManager._mQuest._mDescription + "\n");
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write("Progression : " + QuestManager._mQuest._mProgress + "\n");
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write("Total : " + QuestManager._mQuest._mTotal + "\n");
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write("Récompense : " + QuestManager._mQuest._mReward + "\n");
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write("Quête terminée : " + QuestManager._mQuest._mDone + "\n");
        }
    }
}
