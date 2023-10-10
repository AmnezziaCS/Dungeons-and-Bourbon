using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Monster: Entity, IAttack
    {
        public Monster(int damage, int health, int speed, int luck, string name): base(damage, health, speed, luck, name)
        {
        }

        public int attack(int bonusDamage = 0)
        {
            var rand = new Random();
            double damageMultiplicator = (rand.NextDouble() * 2) + (this.Luck * 0.1);

            return Convert.ToInt32(this.Damage * damageMultiplicator);
        }
    }
}
