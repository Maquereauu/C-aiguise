using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Map
    {
        private List<Zone> _zones;
        private Zone _currentZone;

        public Map() 
        { 
            _zones = new List<Zone>();
            _currentZone = new Zone("none");
        }    

        public void AddZone(Zone zone)
        {
            _zones.Add(zone);
        }

        public void SetCurrentZone(Zone zone)
        {
            _currentZone = zone;
        }
        public void SetCurrentZone()
        {
            _currentZone = _zones[0];
        }

        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            _currentZone.Display();
        }

        public Zone GetCurrentZone() 
        { 
            return _currentZone;
        }

    }
}