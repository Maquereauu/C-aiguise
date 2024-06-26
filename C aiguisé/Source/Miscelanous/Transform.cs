﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace C_aiguisé
{
    public class Transform
    {
        private Utils.vect2 _coordinates;
        private Utils.vect2 _size;

        public Utils.vect2 _mCoordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public Utils.vect2 _mSize
        {
            get { return _size; }
            set { _size = value; }
        }
        public Transform()
        {
            _coordinates = new Utils.vect2();
            _size = new Utils.vect2();
        }

        public void SetPos(int x, int y)
        {
            _coordinates.SetX(x);
            _coordinates.SetY(y);

        }

        public void SetSize(int x, int y)
        {
            _size.SetX(x);
            _size.SetY(y);

        }

        public void Translate(int x, int y)
        {
            _coordinates.AddX(x);
            _coordinates.AddY(y);
        }
    }
}