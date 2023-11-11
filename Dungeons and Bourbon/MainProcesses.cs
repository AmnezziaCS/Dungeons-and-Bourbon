using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_and_Bourbon
{
    public class MainProcesses
    {
        public static bool inBuildingProcess(GameContext db, Player mainPlayer)
        {
            string innASCIIString = Utils.getASCIIArt("Inn");
            string shopASCIIString = Utils.getASCIIArt("Shop");
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
                    Console.Clear();
                    Console.WriteLine(shopASCIIString);
                    Console.WriteLine("Vous êtes dans le magasin."); // Will do
                    Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                    Console.ReadKey();
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
                            if (mainPlayer.MaximumStageReached == selectedStage.Id)
                            {
                                mainPlayer.MaximumStageReached += 1;
                            }
                            // Update Player level
                            db.Players.Update(mainPlayer);
                        }
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
