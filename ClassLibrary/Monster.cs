using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
    public class Monster: Entity, IAttack
    {
        public List<Stage> Stages { get; set; } = new();

        /// <summary>
        /// EF constructor
        /// </summary>
        public Monster() : base()
        { }

        public int attack(int bonusDamage = 0)
        {
            var rand = new Random();
            double damageMultiplicator = (rand.NextDouble() * 2) + (this.Luck * 0.1);

            return Convert.ToInt32(this.Damage * damageMultiplicator);
        }
    }
}
