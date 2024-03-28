using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    static class QuestManager
    {
        private static Quest _quest = null;

        public static Quest _mQuest 
        {
            get { return _quest; }
            set { _quest = value; }
        }

        public static void SetQuest(Quest quest)
        {
            if (_quest == null || _quest._mClear == true)
            {
                _quest = quest;
            }
        }

        public static void Update(int progress)
        {
            _quest.Update(progress);
        }

        public static void ReturnQuest(List<Player> player) 
        { 
            if (_quest._mDone) 
            {
                _quest.GetReward(player);
                _quest._mClear = true;
            }
            else
            {
                Console.Write("Quest not finished");
            }
        }
    }
}
