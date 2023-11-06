namespace ClassLibrary
{
    public class Stage
    {
        private int _rewardedGold;
        private int _rewardedXP;
        private Monster[] _monsterArray;
        private int _stageId;
        private string _stageName;

        public int RewardedGold { get => _rewardedGold; set => _rewardedGold = value; }
        public int RewardedXP { get => _rewardedXP; set => _rewardedXP = value; }
        public Monster[] MonsterArray { get => _monsterArray; set => _monsterArray = value; }
        public int StageId { get => _stageId; set => _stageId = value; }
        public string StageName { get => _stageName; set => _stageName = value; }

        public Stage(int rewardedGold, int rewardedXP, Monster[] monsterArray, int stageId, string stageName)
        {
            RewardedGold = rewardedGold;
            RewardedXP = rewardedXP;
            MonsterArray = monsterArray;
            StageId = stageId;
            StageName = stageName;
        }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Stage()
        { }
    }
}
