using ClassLibrary;
using System.Runtime.CompilerServices;

namespace Dungeons_and_Bourbon
{
    public class ContextHelper
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

                if (db.Monsters.Any() == false)
                {
                    Monster barGuy = new Monster { Name = "Homme du bar", Damage = 1, Health = 5, Luck = 1, Speed = 1 };
                    Monster drunkBarGuy = new Monster { Name = "Homme du bar bourré", Damage = 1, Health = 6, Luck = 1, Speed = 1 };

                    db.Monsters.Add(barGuy);
                    db.Monsters.Add(drunkBarGuy);

                    var firstStageMonsterArray = new List<Monster>() { barGuy, drunkBarGuy };
                    db.Stages.Add(new Stage { Name = "Taverne", RewardedGold = 1, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                }

                if (db.Players.Any() == false)
                {
                    db.Players.Add(new Player { Name = "Player", TotalGold = 0, TotalXp = 0, CurrentLevel = 1, Damage = 1, Health = 10, Speed = 2, Luck = 1, MaximumStageReached = 1, Weapon = baseWeapon, Armor = baseArmor });
                }

                db.SaveChanges();
            }   
        }
    }
}
