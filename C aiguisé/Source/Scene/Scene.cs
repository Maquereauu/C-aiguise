using System;
using System.Collections.Generic;
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
            _map.Update();
        }
        public virtual void PostUpdate()
        {
        }
        public abstract void LoadScene();

        public virtual void UnLoad()
        {
            Console.Clear();
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

        public void AddZone(Zone zone)
        {
            _map.AddZone(zone);
        }
        public static void OpenMenu()
        {
            SceneManager.SwitchScene("Main Menu");
        }

        public virtual void SetBattle(Battle battle)
        {

        }
    }
}