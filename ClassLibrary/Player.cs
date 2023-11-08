using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
    public class Player: Entity, IAttack
    {
        public int TotalGold { get; set; }
        public int TotalXp { get; set; }
        public int CurrentLevel { get; set; }
        public int MaximumStageReached { get; set; }

        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Player() : base()
        { }

        public int attack(int bonusDamage = 0)
        {
            var rand = new Random();
            double damageMultiplicator = (rand.NextDouble() * 2) + (this.Luck * 0.1);

            return Convert.ToInt32((this.Damage + Weapon.GivenDamage + bonusDamage) * damageMultiplicator);
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
