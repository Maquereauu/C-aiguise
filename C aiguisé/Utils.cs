using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
   namespace Utils
    {
        struct vect2
        {
            int _x;
            int _y;
            public vect2(int x, int y)
            {
                _x = x; _y = y;
            }
            public vect2()
            {
                _x = 0;
                _y = 0;
            }
            public int x()
            {
                return _x;
            }
            public int y()
            {
                return _y;
            }
            public void SetX(int x)
            {
                _x = x;
            }
            public void SetY(int y)
            {
                _y = y;
            }
            public void AddX(int x)
            {
                _x += x;
            }
            public void AddY(int y)
            {
                _y += y;
            }

        }
    }
}