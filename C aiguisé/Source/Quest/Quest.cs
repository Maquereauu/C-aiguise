using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace C_aiguisé
{
    public class Quest
    {
        private string _description;
        private int _progress;
        private int _total;
        private bool _done;
        private int _reward; // exp
        private bool _clear;

        [JsonProperty]
        public string _mDescription
        {
            get { return _description; }
            set { _description = value; }
        }
        [JsonProperty]
        public int _mProgress
        {
            get { return _progress; }
            set { _progress = value; }
        }
        [JsonProperty]
        public int _mTotal
        {
            get { return _total; }
            set { _total = value; }
        }
        [JsonProperty]
        public bool _mDone
        {
            get { return _done; }
            set { _done = value; }
        }

        [JsonProperty]
        public int _mReward
        {
            get { return _reward; }
            set { _reward = value; }
        }

        [JsonProperty]
        public bool _mClear
        {
            get { return _clear; }
            set { _clear = value; }
        }
        [JsonConstructor]
        public Quest()
        {

        }
        public Quest(string description, int total, int progress = 0, bool done = false, int reward = 0, bool clear = false)
        {
            _description = description;
            _total = total;
            _progress = progress;
            _done = done;
            _reward = reward;
            _clear = clear;
        }

        public void VerifyQuestStatus()
        {
            if (_progress >= _total) 
            { 
                _done = true;
            }
        }

        public void GetReward(List<Player> players)
        {
            if (_done == true)
            {
                foreach (Player p in players)
                {
                    p.AddExp(_mReward);
                    p.LevelUp();
                    _done = false;
                }
            }
            else
            {
                Console.Write("This quest is not finished");
            }
        }

        public void Update(int progress)
        {
            _progress += progress;
            VerifyQuestStatus();
        }

    }
}
