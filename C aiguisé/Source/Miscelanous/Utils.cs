using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace C_aiguisé
{
   namespace Utils
   {
        public struct vect2
        {
            private int _x;
            private int _y;

            public int _mX
            {
                get { return _x; }
                set { _x = value; }
            }
            public int _mY
            {
                get { return _y; }
                set { _y = value; }
            }


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