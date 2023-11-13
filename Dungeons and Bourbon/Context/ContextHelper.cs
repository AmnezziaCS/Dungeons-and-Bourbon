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
                    Weapon sword = new Weapon { Name = "Epée", Price = 430, GivenDamage = 2 };
                    Weapon axe = new Weapon { Name = "Hache", Price = 500, GivenDamage = 3 };
                    Weapon mace = new Weapon { Name = "Masse", Price = 720, GivenDamage = 4 };
                    Weapon bow = new Weapon { Name = "Arc", Price = 1000, GivenDamage = 5 };
                    Weapon crossbow = new Weapon { Name = "Arbalète", Price = 1500, GivenDamage = 6 };
                    Weapon dagger = new Weapon { Name = "Dague", Price = 2000, GivenDamage = 7 };
                    Weapon spear = new Weapon { Name = "Lance", Price = 2500, GivenDamage = 8 };
                    Weapon halberd = new Weapon { Name = "Hallebarde", Price = 3000, GivenDamage = 9 };
                    db.Weapons.Add(baseWeapon);
                    db.Weapons.Add(sword);
                    db.Weapons.Add(axe);
                    db.Weapons.Add(mace);
                    db.Weapons.Add(bow);
                    db.Weapons.Add(crossbow);
                    db.Weapons.Add(dagger);
                    db.Weapons.Add(spear);
                    db.Weapons.Add(halberd);
                }

                if (db.Armors.Any() == false)
                {
                    Armor leatherArmor = new Armor { Name = "Armure en cuir", Price = 50, GivenHealth = 2 };
                    Armor chainMail = new Armor { Name = "Armure en maille", Price = 100, GivenHealth = 3 };
                    Armor plateArmor = new Armor { Name = "Armure en plaque", Price = 350, GivenHealth = 4 };
                    Armor fullPlateArmor = new Armor { Name = "Armure en plaque complète", Price = 500, GivenHealth = 5 };
                    Armor shield = new Armor { Name = "Bouclier", Price = 1000, GivenHealth = 6 };
                    Armor magicArmor = new Armor { Name = "Armure magique", Price = 1500, GivenHealth = 7 };
                    Armor magicShield = new Armor { Name = "Bouclier magique", Price = 2000, GivenHealth = 8 };

                    db.Armors.Add(baseArmor);
                    db.Armors.Add(leatherArmor);
                    db.Armors.Add(chainMail);
                    db.Armors.Add(plateArmor);
                    db.Armors.Add(fullPlateArmor);
                    db.Armors.Add(shield);
                    db.Armors.Add(magicArmor);
                    db.Armors.Add(magicShield);
                }

                if (db.ConsumableStatUpItems.Any() == false)
                {
                    ConsumableStatUpItem beer = new ConsumableStatUpItem { Name = "Bière", Price = 1, GivenHealth = 1 };
                    ConsumableStatUpItem rock = new ConsumableStatUpItem { Name = "Caillou", Price = 1, GivenDamage = 1 };
                    ConsumableStatUpItem wine = new ConsumableStatUpItem { Name = "Vin", Price = 3, GivenHealth = 3 };
                    ConsumableStatUpItem englishBeer = new ConsumableStatUpItem { Name = "Bière anglaise", Price = 3, GivenDamage = 3 };
                    ConsumableStatUpItem scotch = new ConsumableStatUpItem { Name = "whisky", Price = 15, GivenHealth = 6 };
                    ConsumableStatUpItem cognac = new ConsumableStatUpItem { Name = "cognac", Price = 26, GivenHealth = 10 };
                    ConsumableStatUpItem poison = new ConsumableStatUpItem { Name = "poison", Price = 56, GivenDamage = 10 };

                    db.ConsumableStatUpItems.Add(baseConsumableStatUpItem);
                    db.ConsumableStatUpItems.Add(beer);
                    db.ConsumableStatUpItems.Add(rock);
                    db.ConsumableStatUpItems.Add(wine);
                    db.ConsumableStatUpItems.Add(englishBeer);
                    db.ConsumableStatUpItems.Add(scotch);
                    db.ConsumableStatUpItems.Add(cognac);
                    db.ConsumableStatUpItems.Add(poison);
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
                    // Level 1 : Taverne

                    Monster barGuy = new Monster { Name = "Homme du bar", Damage = 1, Health = 5, Luck = 1, Speed = 1 };
                    Monster drunkBarGuy = new Monster { Name = "Homme du bar bourré", Damage = 1, Health = 6, Luck = 1, Speed = 1 };
                    Monster barGuyLvl2 = new Monster { Name = "Homme du bar", Damage = 1, Health = 6, Luck = 1, Speed = 1 };
                    Monster drunkBarGuyLvl2 = new Monster { Name = "Homme du bar bourré", Damage = 1, Health = 7, Luck = 1, Speed = 1 };
                    Monster barGuyLvl3 = new Monster { Name = "Homme du bar", Damage = 2, Health = 6, Luck = 1, Speed = 1 };
                    Monster drunkBarGuyLvl3 = new Monster { Name = "Homme du bar bourré", Damage = 2, Health = 7, Luck = 1, Speed = 1 };
                    Monster barGuyLvl4 = new Monster { Name = "Homme du bar", Damage = 2, Health = 6, Luck = 1, Speed = 2 };
                    Monster drunkBarGuyLvl4 = new Monster { Name = "Homme du bar bourré", Damage = 2, Health = 7, Luck = 1, Speed = 2 };
                    Monster barGuyLvl5 = new Monster { Name = "Homme du bar", Damage = 3, Health = 7, Luck = 1, Speed = 3 };
                    Monster drunkBarGuyLvl5 = new Monster { Name = "Homme du bar bourré", Damage = 3, Health = 8, Luck = 1, Speed = 2 };

                    db.Monsters.Add(barGuy);
                    db.Monsters.Add(drunkBarGuy);
                    db.Monsters.Add(barGuyLvl2);
                    db.Monsters.Add(drunkBarGuyLvl2);
                    db.Monsters.Add(barGuyLvl3);
                    db.Monsters.Add(drunkBarGuyLvl3);
                    db.Monsters.Add(barGuyLvl4);
                    db.Monsters.Add(drunkBarGuyLvl4);
                    db.Monsters.Add(barGuyLvl5);
                    db.Monsters.Add(drunkBarGuyLvl5);

                    var firstStageMonsterArray = new List<Monster>() { barGuy, drunkBarGuy };
                    var firstStageMonsterArrayLvl2 = new List<Monster>() { barGuyLvl2, drunkBarGuyLvl2 };
                    var firstStageMonsterArrayLvl3 = new List<Monster>() { barGuyLvl3, drunkBarGuyLvl3 };
                    var firstStageMonsterArrayLvl4 = new List<Monster>() { barGuyLvl4, drunkBarGuyLvl4 };
                    var firstStageMonsterArrayLvl5 = new List<Monster>() { barGuyLvl5, drunkBarGuyLvl5 };

                    db.Stages.Add(new Stage { Name = "Taverne *", RewardedGold = 3, RewardedXP = 1, MonsterList = firstStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "Taverne * *", RewardedGold = 5, RewardedXP = 3, MonsterList = firstStageMonsterArrayLvl2 });
                    db.Stages.Add(new Stage { Name = "Taverne * * *", RewardedGold = 7, RewardedXP = 5, MonsterList = firstStageMonsterArrayLvl3 });
                    db.Stages.Add(new Stage { Name = "Taverne * * * * ", RewardedGold = 9, RewardedXP = 7, MonsterList = firstStageMonsterArrayLvl4 });
                    db.Stages.Add(new Stage { Name = "Taverne * * * * *", RewardedGold = 11, RewardedXP = 9, MonsterList = firstStageMonsterArrayLvl5 });

                    // Level 2 : La forêt de Reelig Glen

                    Monster elfArcher = new Monster { Name = "Archer elfe", Damage = 2, Health = 6, Luck = 1, Speed = 2 };
                    Monster elfWarrior = new Monster { Name = "Guerrier elfe", Damage = 1, Health = 8, Luck = 1, Speed = 1 };
                    Monster elfLeader = new Monster { Name = "Leader des elfes", Damage= 3, Health = 12,Luck = 1, Speed = 3 };
                    Monster elfArcherlvl2 = new Monster { Name = "Archer elfe", Damage = 2, Health = 8, Luck = 1, Speed = 2 };
                    Monster elfWarriorlvl2 = new Monster { Name = "Guerrier elfe", Damage = 1, Health = 10, Luck = 1, Speed = 1 };
                    Monster elfLeaderlvl2 = new Monster { Name = "Leader des elfes", Damage = 3, Health = 14, Luck = 1, Speed = 3 };
                    Monster elfArcherlvl3 = new Monster { Name = "Archer elfe", Damage = 3, Health = 8, Luck = 1, Speed = 2 };
                    Monster elfWarriorlvl3 = new Monster { Name = "Guerrier elfe", Damage = 2, Health = 10, Luck = 1, Speed = 1 };
                    Monster elfLeaderlvl3 = new Monster { Name = "Leader des elfes", Damage = 4, Health = 14, Luck = 1, Speed = 3 };
                    Monster elfArcherlvl4 = new Monster { Name = "Archer elfe", Damage = 4, Health = 8, Luck = 1, Speed = 2 };
                    Monster elfWarriorlvl4 = new Monster { Name = "Guerrier elfe", Damage = 3, Health = 20, Luck = 1, Speed = 1 };
                    Monster elfLeaderlvl4 = new Monster { Name = "Leader des elfes", Damage = 4, Health = 16, Luck = 1, Speed = 3 };
                    Monster elfArcherlvl5 = new Monster { Name = "Archer elfe", Damage = 5, Health = 8, Luck = 1, Speed = 3 };
                    Monster elfWarriorlvl5 = new Monster { Name = "Guerrier elfe", Damage = 4, Health = 22, Luck = 1, Speed = 2 };
                    Monster elfLeaderlvl5 = new Monster { Name = "Leader des elfes", Damage = 4, Health = 16, Luck = 1, Speed = 4 };

                    db.Monsters.Add(elfArcher);
                    db.Monsters.Add(elfWarrior);
                    db.Monsters.Add(elfLeader);
                    db.Monsters.Add(elfArcherlvl2);
                    db.Monsters.Add(elfWarriorlvl2);
                    db.Monsters.Add(elfLeaderlvl2);
                    db.Monsters.Add(elfArcherlvl3);
                    db.Monsters.Add(elfWarriorlvl3);
                    db.Monsters.Add(elfLeaderlvl3);
                    db.Monsters.Add(elfArcherlvl4);
                    db.Monsters.Add(elfWarriorlvl4);
                    db.Monsters.Add(elfLeaderlvl4);
                    db.Monsters.Add(elfArcherlvl5);
                    db.Monsters.Add(elfWarriorlvl5);
                    db.Monsters.Add(elfLeaderlvl5);

                    var secondStageMonsterArray = new List<Monster>() { elfArcher, elfWarrior, elfLeader };
                    var secondStageMonsterArraylvl2 = new List<Monster>() { elfArcherlvl2, elfWarriorlvl2, elfLeaderlvl2 };
                    var secondStageMonsterArraylvl3 = new List<Monster>() { elfArcherlvl3, elfWarriorlvl3, elfLeaderlvl3 };
                    var secondStageMonsterArraylvl4 = new List<Monster>() { elfArcherlvl4, elfWarriorlvl4, elfLeaderlvl4 };
                    var secondStageMonsterArraylvl5 = new List<Monster>() { elfArcherlvl5, elfWarriorlvl5, elfLeaderlvl5 };

                    db.Stages.Add(new Stage { Name = "La foret de Reelig Glen *", RewardedGold = 9, RewardedXP = 2, MonsterList = secondStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "La foret de Reelig Glen * *", RewardedGold = 15, RewardedXP = 6, MonsterList = secondStageMonsterArraylvl2 });
                    db.Stages.Add(new Stage { Name = "La foret de Reelig Glen * * *", RewardedGold = 21, RewardedXP = 10, MonsterList = secondStageMonsterArraylvl3 });
                    db.Stages.Add(new Stage { Name = "La foret de Reelig Glen * * * *", RewardedGold = 28, RewardedXP = 14, MonsterList = secondStageMonsterArraylvl4 });
                    db.Stages.Add(new Stage { Name = "La foret de Reelig Glen * * * * *", RewardedGold = 33, RewardedXP = 18, MonsterList = secondStageMonsterArraylvl5 });

                    // Level 3 : L'île de Skye

                    Monster wolf = new Monster { Name = "Loup affamé", Damage = 8, Health = 5, Luck = 1, Speed = 3 };
                    Monster fenrir = new Monster { Name = "Fenrir", Damage = 5, Health = 15, Luck = 1, Speed = 2 };
                    Monster wolfLvl2 = new Monster { Name = "Loup affamé", Damage = 8, Health = 5, Luck = 1, Speed = 3 };
                    Monster fenrirLvl2 = new Monster { Name = "Fenrir", Damage = 6, Health = 15, Luck = 1, Speed = 2 };
                    Monster wolfLvl3 = new Monster { Name = "Loup affamé", Damage = 8, Health = 8, Luck = 1, Speed = 3 };
                    Monster fenrirLvl3 = new Monster { Name = "Fenrir", Damage = 7, Health = 15, Luck = 1, Speed = 3 };
                    Monster wolfLvl4 = new Monster { Name = "Loup affamé", Damage = 8, Health = 8, Luck = 1, Speed = 3 };
                    Monster fenrirLvl4 = new Monster { Name = "Fenrir", Damage = 7, Health = 17, Luck = 1, Speed = 3 };
                    Monster wolfLvL5 = new Monster { Name = "Loup affamé", Damage = 9, Health = 8, Luck = 1, Speed = 3 };
                    Monster fenrirLvl5 = new Monster { Name = "Fenrir", Damage = 7, Health = 17, Luck = 1, Speed = 3 };

                    db.Monsters.Add(wolf);
                    db.Monsters.Add(fenrir);
                    db.Monsters.Add(wolfLvl2);
                    db.Monsters.Add(fenrirLvl2);
                    db.Monsters.Add(wolfLvl3);
                    db.Monsters.Add(fenrirLvl3);
                    db.Monsters.Add(wolfLvl4);
                    db.Monsters.Add(fenrirLvl4);
                    db.Monsters.Add(wolfLvL5);
                    db.Monsters.Add(fenrirLvl5);

                    var thirdStageMonsterArray = new List<Monster>() { wolf, fenrir};
                    var thirdStageMonsterArrayLvl2 = new List<Monster>() { wolfLvl2, fenrirLvl2 };
                    var thirdStageMonsterArrayLvl3 = new List<Monster>() { wolfLvl3, fenrirLvl3 };
                    var thirdStageMonsterArrayLvl4 = new List<Monster>() { wolfLvl4, fenrirLvl4 };
                    var thirdStageMonsterArrayLvl5 = new List<Monster>() { wolfLvL5, fenrirLvl5 };

                    db.Stages.Add(new Stage { Name = "L'île de Skye *", RewardedGold = 28, RewardedXP = 4, MonsterList = thirdStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "L'île de Skye * *", RewardedGold = 45, RewardedXP = 12, MonsterList = thirdStageMonsterArrayLvl2 });
                    db.Stages.Add(new Stage { Name = "L'île de Skye * * *", RewardedGold = 63, RewardedXP = 20, MonsterList = thirdStageMonsterArrayLvl3 });
                    db.Stages.Add(new Stage { Name = "L'île de Skye * * * *", RewardedGold = 84, RewardedXP = 28, MonsterList = thirdStageMonsterArrayLvl4 });
                    db.Stages.Add(new Stage { Name = "L'île de Skye * * * * *", RewardedGold = 99, RewardedXP = 36, MonsterList = thirdStageMonsterArrayLvl5 });

                    // Level 4 : Glenn coe

                    Monster draugr = new Monster { Name = "Draugr", Damage = 1, Health = 5, Luck = 1, Speed = 6 };
                    Monster jotunn = new Monster { Name = "Jotunn", Damage = 5, Health = 30, Luck = 1, Speed = 2 };
                    Monster draugrLvl2 = new Monster { Name = "Draugr", Damage = 2, Health = 6, Luck = 1, Speed = 6 };
                    Monster jotunnLvl2 = new Monster { Name = "Jotunn", Damage = 5, Health = 30, Luck = 1, Speed = 3 };
                    Monster draugrLvl3 = new Monster { Name = "Draugr", Damage = 2, Health = 9, Luck = 1, Speed = 6 };
                    Monster jotunnLvl3 = new Monster { Name = "Jotunn", Damage = 6, Health = 30, Luck = 1, Speed = 4 };
                    Monster draugrLvl4 = new Monster { Name = "Draugr", Damage = 2, Health = 12, Luck = 1, Speed = 6 };
                    Monster jotunnLvl4 = new Monster { Name = "Jotunn", Damage = 6, Health = 30, Luck = 1, Speed = 4 };
                    Monster draugrLvl5 = new Monster { Name = "Draugr", Damage = 2, Health = 14, Luck = 1, Speed = 6 };
                    Monster jotunnLvl5 = new Monster { Name = "Jotunn", Damage = 8, Health = 30, Luck = 1, Speed = 5 };

                    db.Monsters.Add(draugr);
                    db.Monsters.Add(jotunn);
                    db.Monsters.Add(draugrLvl2);
                    db.Monsters.Add(jotunnLvl2);
                    db.Monsters.Add(draugrLvl3);
                    db.Monsters.Add(jotunnLvl3);
                    db.Monsters.Add(draugrLvl4);
                    db.Monsters.Add(jotunnLvl4);
                    db.Monsters.Add(draugrLvl5);
                    db.Monsters.Add(jotunnLvl5);

                    var fourthStageMonsterArray = new List<Monster>() { draugr , draugr , draugr , jotunn };
                    var fourthStageMonsterArrayLvl2 = new List<Monster>() { draugrLvl2, draugr, jotunnLvl2 };
                    var fourthStageMonsterArrayLvl3 = new List<Monster>() { draugrLvl3, draugrLvl2, draugr, jotunnLvl3 };
                    var fourthStageMonsterArrayLvl4 = new List<Monster>() { draugrLvl3, draugrLvl4, draugrLvl2, jotunnLvl4 };
                    var fourthStageMonsterArrayLvl5 = new List<Monster>() { draugrLvl3, draugrLvl5, draugrLvl4, jotunnLvl5 };

                    db.Stages.Add(new Stage { Name = "Glenn coe *", RewardedGold = 84, RewardedXP = 8, MonsterList = fourthStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "Glenn coe * *", RewardedGold = 135, RewardedXP = 24, MonsterList = fourthStageMonsterArrayLvl2 });
                    db.Stages.Add(new Stage { Name = "Glenn coe * * *", RewardedGold = 186, RewardedXP = 40, MonsterList = fourthStageMonsterArrayLvl3 });
                    db.Stages.Add(new Stage { Name = "Glenn coe * * * *", RewardedGold = 252, RewardedXP = 56, MonsterList = fourthStageMonsterArrayLvl4 });
                    db.Stages.Add(new Stage { Name = "Glenn coe * * * * *", RewardedGold = 297, RewardedXP = 72, MonsterList = fourthStageMonsterArrayLvl5 });

                    // Level 5 : Loch Ness

                    Monster nessy = new Monster { Name = "Nessy", Damage = 10, Health = 75, Luck = 1, Speed = 4 };

                    db.Monsters.Add(nessy);

                    var LastStageMonsterArray = new List<Monster>() { draugr, wolf , draugr, nessy};
                    var LastStageMonsterArrayLvl2 = new List<Monster>() { draugrLvl2, wolfLvl3, draugr, nessy };
                    var LastStageMonsterArrayLvl3 = new List<Monster>() { draugrLvl3, wolfLvl3, draugrLvl2, nessy };
                    var LastStageMonsterArrayLvl4 = new List<Monster>() { draugrLvl4, wolfLvl3, draugrLvl3, nessy };
                    var LastStageMonsterArrayLvl5 = new List<Monster>() { elfLeaderlvl5, fenrirLvl5, barGuyLvl5, nessy };

                    db.Stages.Add(new Stage { Name = "Loch Ness *", RewardedGold = 252, RewardedXP = 13, MonsterList = LastStageMonsterArray });
                    db.Stages.Add(new Stage { Name = "Loch Ness * *", RewardedGold = 405, RewardedXP = 48, MonsterList = LastStageMonsterArrayLvl2 });
                    db.Stages.Add(new Stage { Name = "Loch Ness * * *", RewardedGold = 567, RewardedXP = 80, MonsterList = LastStageMonsterArrayLvl3 });
                    db.Stages.Add(new Stage { Name = "Loch Ness * * * *", RewardedGold = 756, RewardedXP = 112, MonsterList = LastStageMonsterArrayLvl4 });
                    db.Stages.Add(new Stage { Name = "Loch Ness * * * * *", RewardedGold = 891, RewardedXP = 144, MonsterList = LastStageMonsterArrayLvl5 });

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
