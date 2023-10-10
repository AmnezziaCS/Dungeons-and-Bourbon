using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Player: Entity, IAttack
    {
        private int _totalGold;
        private int _totalXp;
        private int _currentLevel;
        private Weapon _currentWeapon;
        private Armor _currentArmor;
        private List<Item> _inventory;

        public int TotalGold { get => _totalGold; set => _totalGold = value; }
        public int TotalXp { get => _totalXp; set => _totalXp = value; }
        public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        public Armor CurrentArmor { get => _currentArmor; set => _currentArmor = value; }
        public List<Item> Inventory { get => _inventory; set => _inventory = value; }

        public Player(int totalGold, int totalXp, int currentLevel, Weapon currentWeapon, Armor currentArmor,  int damage, int health, int speed, int luck, string name, List<Item> inventory) : base(damage, health, speed, luck, name)
        {
            TotalGold = totalGold;
            TotalXp = totalXp;
            CurrentLevel = currentLevel;
            CurrentWeapon = currentWeapon;
            CurrentArmor = currentArmor;
            Inventory = inventory;
         }

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

        public void addItemToInventory(Item itemToAdd)
        {
            Inventory.Add(itemToAdd);
        }
    }
}
