using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public abstract class Scene
    {
        protected string _name;
        protected Map _map;
        protected Battle _battle;
        protected Bitmap _bitmap;
        protected bool _isGameZone;
        public Bitmap bitmap { get { return _bitmap; } }

        public Scene(string name)
        {
            _name = name;
            _map = new Map();
        }
        public abstract void Init();
        public virtual void PreUpdate()
        {
        }
        public virtual void Update()
        {
            Console.SetCursorPosition(0, 0);
            _map.Update();
        }
        public virtual void PostUpdate()
        {
        }
        public abstract void LoadScene();

        public virtual void UnLoad()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public string GetName()
        {
            return _name;
        }
        public Map GetMap()
        {
            return _map;
        }

        public bool GetIsGameZone()
        {
            return _isGameZone;
        }

        public void AddZone(Zone zone)
        {
            _map.AddZone(zone);
        }
        public static void OpenMenu()
        {
            if (SceneManager.IsSceneExist("MainMenu"))
            {
                SceneManager.SwitchScene("MainMenu");
            }
        }

        public virtual void SetBattle(Battle battle)
        {

        }
        public virtual void Swap()
        {

        }
    }
}