using ClassLibrary;

namespace Dungeons_and_Bourbon
{
    public class contextHelper
    {
        public static void initializeContext()
        {
            using (var db = new GameContext())
            {
                Weapon baseWeapon = new Weapon { Name = "Verre", Price = 0, GivenDamage = 1 };
                Armor baseArmor = new Armor { Name = "Manteau", Price = 0, GivenHealth = 1 };

                if (db.Weapons.Any() == false)
                {
                    db.Weapons.Add(baseWeapon);
                }

                if (db.Armors.Any() == false)
                {
                    db.Armors.Add(baseArmor);
                }

                if (db.Players.Any() == false)
                {
                    db.Players.Add(new Player { Name = "Player", TotalGold = 0, TotalXp = 0, CurrentLevel = 1, Damage = 2, Health = 10, Speed = 2, Luck = 1, MaximumStageReached = 1, CurrentArmor = baseArmor, CurrentWeapon = baseWeapon });
                }

                db.SaveChanges();
            }
        }
    }
}
