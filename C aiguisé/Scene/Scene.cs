using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public abstract class Scene
    {
        protected string _name;
        protected Map _map;

        public Scene(string name)
        {
            _name = name;
            _map = new Map();
        }
        public abstract void Init();
        public virtual void PreUpdate()
        {
            Console.SetCursorPosition(0, 0);
        }
        public virtual void Update()
        {
            Console.SetCursorPosition(0, 0);
            _map.Update();
        }
        public virtual void PostUpdate()
        {
            Console.SetCursorPosition(0, 0);
        }
        public abstract void LoadScene();

        public abstract void UnLoad();

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
    }
}