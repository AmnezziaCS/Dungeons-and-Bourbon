using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_and_Bourbon
{
    public class Menu
    {
        public static void renderMenu(GameContext db)
        {
            bool isOn = true;
            Player mainPlayer = db.Players.Include(player => player.Weapon).Include(player => player.Armor).Include(player => player.ConsumableStatUpItem).First();
            List<Stage> stages = db.Stages.Include(stage => stage.MonsterList).ToList();

            string startTitleASCIIString = Utils.getASCIIArt("StartMenu");
            string menuASCIIString = Utils.getASCIIArt("Menu");
            string endTitleASCIIString = Utils.getASCIIArt("ExitMenu");

            Console.WriteLine(startTitleASCIIString);
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine(menuASCIIString);
                Console.Write("\nMenu : \n\n1 - Voyager\n\n2 - Aller au centre-ville\n\n3 - Voir mon équipement\n\n4 - Quitter\n");
                string userGlobalMenuPickStringified = Console.ReadLine();
                int userGlobalMenuPick;

                if (!int.TryParse(userGlobalMenuPickStringified, out userGlobalMenuPick))
                {
                    Utils.userChoiceErrorMessage();
                    continue;
                }

                switch (userGlobalMenuPick)
                {
                    case 1:
                        bool inStageSelection = true;
                        do
                        {
                            inStageSelection = MainProcesses.inStageSelectionProcess(db, mainPlayer, stages);
                        } while (inStageSelection);
                        break;
                    case 2:
                        bool inBuilding = true;
                        do
                        {
                            inBuilding = MainProcesses.inBuildingProcess(db, mainPlayer);
                        } while (inBuilding);
                        break;
                    case 3:
                        string consumableBuffer = mainPlayer.ConsumableStatUpItem != null ? mainPlayer.ConsumableStatUpItem.returnItemAsString() : "Vous n'avez pas d'objet consommable.";
                        Console.Clear();
                        Console.WriteLine("Voici votre équipement :\n");
                        Console.WriteLine($"{mainPlayer.Weapon.returnItemAsString()}");
                        Console.WriteLine($"{mainPlayer.Armor.returnItemAsString()}");
                        Console.WriteLine($"{consumableBuffer}\n");
                        Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                        Console.ReadKey();
                        break;
                    case 4:
                        isOn = false;
                        Console.Clear();
                        Console.Write(endTitleASCIIString);
                        Console.ReadKey();
                        break;
                    default:
                        Utils.userChoiceErrorMessage();
                        break;
                }
            } while (isOn);
        }
    }
}