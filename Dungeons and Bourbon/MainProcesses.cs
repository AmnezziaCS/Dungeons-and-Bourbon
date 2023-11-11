using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_and_Bourbon
{
    public class MainProcesses
    {
        public static bool inBuildingProcess(GameContext db, Player mainPlayer)
        {
            string innASCIIString = Utils.getASCIIArt("Inn");
            Console.Clear();
            Console.Write("Vous vous retrouvez face à deux bâtiments, dans lequel rentrez-vous :\n\n1 - Entrer dans le magasin\n\n2 - Entrer dans l'auberge de la flûte étincellante\n\n3 - Retour vers l'entrée du village\n");

            string userBuildingMenuPickStringified = Console.ReadLine();
            int userBuildingMenuPick;

            if (!int.TryParse(userBuildingMenuPickStringified, out userBuildingMenuPick))
            {
                Utils.userChoiceErrorMessage();
                return true;
            }

            switch (userBuildingMenuPick)
            {
                case 1:
                    bool inShopProcess = true;
                    do
                    {
                        inShopProcess = MainProcesses.inShopProcess(db, mainPlayer);
                    } while (inShopProcess);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(innASCIIString);
                    Console.WriteLine("\nVous entrez dans l'auberge de la flûte étincellante...\nAprès quelques pintes, vous avez comme l'impression que le monde à changé.\nOn dirait bien que votre progression a été sauvegardée!");
                    Console.WriteLine("\n[Appuyez sur Entrée pour continuer...]");
                    db.SaveChanges();
                    Console.ReadKey();
                    break;
                case 3:
                    return false;
                default:
                    Utils.userChoiceErrorMessage();
                    break;
            }
            return true;
        }

        public static bool inShopProcess(GameContext db, Player mainPlayer)
        {
            string shopASCIIString = Utils.getASCIIArt("Shop");
            Shop shop = db.Shops.Include(shop => shop.ItemList).First();
            
            Console.Clear();
            Console.WriteLine(shopASCIIString);
            Console.WriteLine("\nVous entrez dans le magasin.");
            Console.WriteLine("Vous avez actuellement " + mainPlayer.TotalGold + " pièces d'or.");
            Console.WriteLine("Voici les objets disponibles à l'achat :\n");
            shop.renderItemList();
            Console.WriteLine("\n0 - Quitter le magasin\n");

            string userShopMenuPickStringified = Console.ReadLine();
            int userShopMenuPick;

            if (!int.TryParse(userShopMenuPickStringified, out userShopMenuPick))
            {
                Utils.userChoiceErrorMessage();
                return true;
            }

            switch (userShopMenuPick)
            {
                case 0:
                    return false;
                default:
                    if (userShopMenuPick <= shop.ItemList.Count && userShopMenuPick > 0)
                    {
                        Console.Clear();
                        if (mainPlayer.TotalGold >= shop.ItemList[userShopMenuPick - 1].Price)
                        {
                            shop.buyItem(userShopMenuPick - 1, mainPlayer);
                            db.SaveChanges();
                            Console.WriteLine("\n[Appuyez sur Entrée pour continuer...]");
                            Console.ReadKey();
                            return false;
                        }
                        Console.WriteLine("Vous n'avez pas assez d'argent pour acheter l'objet !");
                        Console.WriteLine("\n[Appuyez sur Entrée pour continuer...]");
                        Console.ReadKey();
                        return false;
                    }
                    Utils.userChoiceErrorMessage();
                    break;
            }
            return true;
        }

        public static bool inStageSelectionProcess(GameContext db, Player mainPlayer, List<Stage> stages)
        {
            Console.Clear();
            Console.WriteLine("Vers quelle contrée voulez-vous voyager ?");
            Utils.renderAvailableStages(mainPlayer, stages);

            string userStagesSelectionPickStringified = Console.ReadLine();
            int userStagesSelectionPick;

            if (!int.TryParse(userStagesSelectionPickStringified, out userStagesSelectionPick))
            {
                Utils.userChoiceErrorMessage();
                return true;
            }

            switch (userStagesSelectionPick)
            {
                case 0:
                    return false;
                default:
                    if (userStagesSelectionPick <= mainPlayer.MaximumStageReached && userStagesSelectionPick > 0)
                    {
                        Console.Clear();
                        Stage selectedStage = stages.ElementAt(userStagesSelectionPick - 1);
                        Combat combat = new Combat(mainPlayer, selectedStage);
                        do
                        {
                            combat.nextTurn();
                        } while (combat.Status == "ongoing");

                        if (combat.Status != "defeat")
                        {
                            mainPlayer.TotalGold += selectedStage.RewardedGold;
                            mainPlayer.TotalXp += selectedStage.RewardedXP;
                            if (mainPlayer.MaximumStageReached == selectedStage.Id && selectedStage.Id != 15)
                            {
                                mainPlayer.MaximumStageReached += 1;
                            }
                            // Update Player level
                            mainPlayer.updateStats();
                            db.Players.Update(mainPlayer);
                        }
                        Console.WriteLine("\n[Appuyez sur Entrée pour continuer...]");
                        Console.ReadLine();
                        return false;
                    }
                    Utils.userChoiceErrorMessage();
                    break;
            }
            return true;
        }
    }
}
