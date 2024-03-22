using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace C_aiguisé
{
    public class Save
    {
        // player
        private List<Character> _player;
        private List<Item> _item;
        private List<int> _itemNumber;
        private string _currentZone;
        private Transform _transform;

        public List<Character> _mPlayer
        {
            get { return _player; }
            set { _player = value; }
        }
        public List<Item> _mItem
        {
            get { return _item; }
            set { _item = value; }
        }
        public List<int> _mItemNumber
        {
            get { return _itemNumber; }
            set { _itemNumber = value; }
        }
        public string _mCurrentZone
        {
            get { return _currentZone; }
            set { _currentZone = value; }
        }
        public Transform _mTransform
        {
            get { return _transform; }
            set { _transform = value; }
        }
        public Save()
        {
            _player = new List<Character>();
            _item = new List<Item>();   
            _itemNumber = new List<int>();
            _currentZone = "";
            _transform = new Transform();
    }
    }
}

