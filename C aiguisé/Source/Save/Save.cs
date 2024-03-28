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
        private List<Player> _player;
        private List<Item> _item;
        private List<int> _itemNumber;
        private string _currentZone;
        private Quest _quest;

        public List<Player> _mPlayer
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
        public Quest _mQuest
        {
            get { return _quest; }
            set { _quest = value; }
        }
        public Save()
        {
            _player = new List<Player>();
            _item = new List<Item>();   
            _itemNumber = new List<int>();
            _currentZone = "";
            _quest = new Quest();
        }

        public void SaveGame(string path)
        {
            FileReader.WriteJsonFile(this, path);
        }

        public void LoadGame(string path)
        {
            Save loadedScene = FileReader.ReadJsonFile(path);

            for (int i = 0; i < loadedScene._player.Count; i++)
            {
                Player player = loadedScene._player[i];
                EntityManager.CreatePlayer(player._mName, player._mHp, player._mHpMax,
                    player._mMp, player._mMpMax, player._mLevel, player._mExp,
                    player._mCritChance, player._mCritDamage, player._mDodgeChance,
                    player._mType, player._mSpeed, player._mIsDead, player._mExpToLevelUp,
                    player._mAttackMoves, player._mSummonBar,

                    new Weapon(player._mWeapon._mName, player._mWeapon._mIdamage, player._mWeapon._mCritRate,
                    player._mWeapon._mCritDamage, player._mWeapon._mType, player._mWeapon._mClass),

                    Role.CreateRole(player._mRole._mId)
                    
                    );

                SceneManager.AddScene(new PlayerStatsScene(player));
            }

            for (int i = 0; i < loadedScene._item.Count; i++)
            {
                Bag.AddItem(loadedScene._item[i], loadedScene._itemNumber[i]);
            }

            QuestManager._mQuest = new Quest(_mQuest._mDescription, _mQuest._mType, _mQuest._mTotal, _mQuest._mProgress, _mQuest._mDone, _mQuest._mReward, _mQuest._mClear);

            SceneManager.AddScene(new PlayerScene());

            SceneManager.SwitchScene(loadedScene._currentZone);
        }

    }
}

