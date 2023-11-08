using ClassLibrary;
using System.Runtime.CompilerServices;

namespace Dungeons_and_Bourbon
{
    public class ContextHelper
    {
        public static void initializeItems()
        {
            using (var db = new GameContext())
            {
                if (db.Weapons.Any() == false)
                {
                    db.Weapons.Add(new Weapon { Name = "Verre", Price = 0, GivenDamage = 1 });
                }

                if (db.Armors.Any() == false)
                {
                    db.Armors.Add(new Armor { Name = "Manteau", Price = 0, GivenHealth = 1 });
                }
                db.SaveChanges();
            }
        }

        public static void initializeMonsters()
        {
            using (var db = new GameContext())
            {
                if (db.Monsters.Any() == false)
                {
                    db.Monsters.Add(new Monster { Name = "Homme du bar", Damage = 1, Health = 5, Luck = 1, Speed = 1 });
                    db.Monsters.Add(new Monster { Name = "Homme du bar bourré", Damage = 1, Health = 6, Luck = 1, Speed = 1 });
                }

                db.SaveChanges();
            }
        }

        public static void initializeContext()
        {
            initializeItems();
            initializeMonsters();

            using (var db = new GameContext())
            {
                if (db.Stages.Any() == false)
                {
                    Monster barGuy = db.Monsters.Single(monster => monster.Name == "Homme du bar");
                    Monster drunkBarGuy = db.Monsters.Single(monster => monster.Name == "Homme du bar bourré");
                    var firstStageMonsterArray = new List<Monster>() { barGuy, drunkBarGuy };
                    db.Stages.Add(new Stage { Name = "Taverne", RewardedGold = 1, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                }

                if (db.Players.Any() == false)
                {
                    Weapon baseWeapon = db.Weapons.Single(weapon => weapon.Name == "Verre");
                    Armor baseArmor = db.Armors.Single(armor => armor.Name == "Manteau");
                    db.Players.Add(new Player { Name = "Player", TotalGold = 0, TotalXp = 0, CurrentLevel = 1, Damage = 1, Health = 10, Speed = 2, Luck = 1, MaximumStageReached = 1, Weapon = baseWeapon, Armor = baseArmor });
                }

                db.SaveChanges();
            }   
        }
    }
}
