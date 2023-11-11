using ClassLibrary;

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
                ConsumableStatUpItem baseConsumableStatUpItem = new ConsumableStatUpItem { Name = "Whisky", Price = 0, GivenHealth = 1 };

                if (db.Weapons.Any() == false)
                {
                    Weapon sword = new Weapon { Name = "Epée", Price = 10, GivenDamage = 2 };
                    Weapon axe = new Weapon { Name = "Hache", Price = 15, GivenDamage = 3 };
                    Weapon mace = new Weapon { Name = "Masse", Price = 20, GivenDamage = 4 };
                    db.Weapons.Add(baseWeapon);
                    db.Weapons.Add(sword);
                    db.Weapons.Add(axe);
                    db.Weapons.Add(mace);
                }

                if (db.Armors.Any() == false)
                {
                    Armor leatherArmor = new Armor { Name = "Armure en cuir", Price = 10, GivenHealth = 2 };
                    Armor chainMail = new Armor { Name = "Armure en maille", Price = 15, GivenHealth = 3 };
                    Armor plateArmor = new Armor { Name = "Armure en plaque", Price = 20, GivenHealth = 4 };
                    db.Armors.Add(baseArmor);
                    db.Armors.Add(leatherArmor);
                    db.Armors.Add(chainMail);
                    db.Armors.Add(plateArmor);
                }

                if (db.ConsumableStatUpItems.Any() == false)
                {
                    ConsumableStatUpItem beer = new ConsumableStatUpItem { Name = "Bière", Price = 10, GivenHealth = 2 };
                    ConsumableStatUpItem wine = new ConsumableStatUpItem { Name = "Vin", Price = 15, GivenHealth = 3 };
                    db.ConsumableStatUpItems.Add(baseConsumableStatUpItem);
                    db.ConsumableStatUpItems.Add(beer);
                    db.ConsumableStatUpItems.Add(wine);
                }

                db.SaveChanges();

                if (db.Shops.Any() == false)
                {
                    var weaponList = db.Weapons.ToList();
                    var armorList = db.Armors.ToList();
                    var consumableStatUpItemList = db.ConsumableStatUpItems.ToList();

                    weaponList.Remove(baseWeapon);
                    armorList.Remove(baseArmor);
                    consumableStatUpItemList.Remove(baseConsumableStatUpItem);

                    List<Item> itemList = new List<Item>();
                    itemList.AddRange(weaponList);
                    itemList.AddRange(armorList);
                    itemList.AddRange(consumableStatUpItemList);

                    db.Shops.Add(new Shop { ItemList = itemList });
                }

                if (db.Monsters.Any() == false)
                {
                    Monster barGuy = new Monster { Name = "Homme du bar", Damage = 1, Health = 5, Luck = 1, Speed = 1 };
                    Monster drunkBarGuy = new Monster { Name = "Homme du bar bourré", Damage = 1, Health = 6, Luck = 1, Speed = 1 };

                    db.Monsters.Add(barGuy);
                    db.Monsters.Add(drunkBarGuy);

                    var firstStageMonsterArray = new List<Monster>() { barGuy, drunkBarGuy };
                    db.Stages.Add(new Stage { Name = "Taverne |", RewardedGold = 1, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "Taverne ||", RewardedGold = 1, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "Taverne |||", RewardedGold = 1, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                }

                if (db.Players.Any() == false)
                {
                    db.Players.Add(new Player { Name = "Player", TotalGold = 0, TotalXp = 0, CurrentLevel = 1, Damage = 1, Health = 10, Speed = 2, Luck = 1, MaximumStageReached = 1, Weapon = baseWeapon, Armor = baseArmor, ConsumableStatUpItem = baseConsumableStatUpItem });
                }

                db.SaveChanges();
            }   
        }
    }
}
