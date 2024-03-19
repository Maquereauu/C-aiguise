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

        public Map() { }    

        public void AddZone(Zone zone)
        {
            _zones.Add(zone);
        }

        public void SetCurrentZone(Zone zone)
        {
            _currentZone = zone;
        }

        public void Update()
        {
            _currentZone.Display();
        }

    }
}