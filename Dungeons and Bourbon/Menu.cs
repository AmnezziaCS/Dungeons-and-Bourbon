using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_and_Bourbon
{
    public class Menu
    {
        public static void renderMenu(GameContext db)
        {
            bool isOn = true;
            Player mainPlayer = db.Players.Include(player => player.Weapon).Include(player => player.Armor).First();

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
                        Console.Clear();
                        Console.WriteLine("Vers quelle contrée voulez-vous voyager ?");
                        Utils.renderAvailableStages(db, mainPlayer);
                        Console.ReadKey();
                        break;
                    case 2:
                        bool inBuilding = true;
                        do
                        {
                            inBuilding = MainProccesses.inBuildingProcess(db);
                        } while (inBuilding);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Voir mon équipement :"); // Will do
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