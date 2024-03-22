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
        public Save()
        {
            _player = new List<Character>();
            _item = new List<Item>();   
            _itemNumber = new List<int>();
            _currentZone = "";
        }

        public void SaveGame(string path)
        {
            FileReader.WriteFile(this, path);
        }

        public void LoadGame(string path)
        {
            Save loadedScene = FileReader.ReadFile(path);

            for (int i = 0; i < loadedScene._item.Count; i++)
            {
                Bag.AddItem(loadedScene._item[i], loadedScene._itemNumber[i]);
            }

            SceneManager.SwitchScene(loadedScene._currentZone);
        }

    }
}

