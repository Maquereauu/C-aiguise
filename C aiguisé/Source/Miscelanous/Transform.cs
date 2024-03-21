using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Transform
    {
        private Utils.vect2 _coordinates;
        public Transform()
        {
            _coordinates = new Utils.vect2();
        }

        public void SetPos(int x, int y)
        {
            _coordinates.SetX(x);
            _coordinates.SetX(y);
        }

        public void Translate(int x, int y)
        {
            _coordinates.AddX(x);
            _coordinates.AddY(y);
        }

        public Utils.vect2 GetCoordinates() 
        { 
            return _coordinates; 
        }
    }
}