using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Stage
    {
        private int _rewardedGold;
        private int _rewardedXP;
        private Monster[] _monsterArray;

        public int RewardedGold { get => _rewardedGold; set => _rewardedGold = value; }
        public int RewardedXP { get => _rewardedXP; set => _rewardedXP = value; }
        public Monster[] MonsterArray { get => _monsterArray; set => _monsterArray = value; }

        public Stage(int rewardedGold, int rewardedXP, Monster[] monsterArray)
        {
            RewardedGold = rewardedGold;
            RewardedXP = rewardedXP;
            MonsterArray = monsterArray;
        }
    }
}
