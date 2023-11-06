namespace ClassLibrary
{
    public class Player: Entity, IAttack
    {
        private int _totalGold;
        private int _totalXp;
        private int _currentLevel;
        private Weapon _currentWeapon;
        private Armor _currentArmor;
        private int _maximumStageReached;

        public int TotalGold { get => _totalGold; set => _totalGold = value; }
        public int TotalXp { get => _totalXp; set => _totalXp = value; }
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        public Armor CurrentArmor { get => _currentArmor; set => _currentArmor = value; }
        public int MaximumStageReached { get => _maximumStageReached; set => _maximumStageReached = value; }

        public Player(int totalGold, int totalXp, int currentLevel, Weapon currentWeapon, Armor currentArmor, int damage, int health, int speed, int luck, string name, int maximumStageReached, int id) : base(id, damage, health, speed, luck, name)
        {
            TotalGold = totalGold;
            TotalXp = totalXp;
            CurrentLevel = currentLevel;
            CurrentWeapon = currentWeapon;
            CurrentArmor = currentArmor;
            MaximumStageReached = maximumStageReached;
         }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Player() : base()
        { }

        public int attack(int bonusDamage = 0)
        {
            var rand = new Random();
            double damageMultiplicator = (rand.NextDouble() * 2) + (this.Luck * 0.1);

            return Convert.ToInt32((this.Damage + CurrentWeapon.GivenDamage + bonusDamage) * damageMultiplicator);
        }

        public int getLevelFromXp()
        {
            int xpLeft = this.TotalXp;
            int xpNeededForNextLevel = 10;
            int level = 1;
            
            while (xpLeft > xpNeededForNextLevel)
            {
                level++;
                xpLeft-= xpNeededForNextLevel;
                xpNeededForNextLevel += xpNeededForNextLevel;
            }

            return level;
        }
    }
}
