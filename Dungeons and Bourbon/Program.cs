using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Bourbon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOn = true;

            Console.WriteLine(@"
                        
                 =============================================================================================================================================================
                 =                                                                                                                                                           =        
                 =   .########...#######..##....##.......##..#######..##....##....########.########....########...#######..##.....##.########..########...#######..##....##  =
                 =   .##.....##.##.....##.###...##.......##.##.....##.###...##....##..........##.......##.....##.##.....##.##.....##.##.....##.##.....##.##.....##.###...##  =
                 =   .##.....##.##.....##.####..##.......##.##.....##.####..##....##..........##.......##.....##.##.....##.##.....##.##.....##.##.....##.##.....##.####..##  =
                 =   .##.....##.##.....##.##.##.##.......##.##.....##.##.##.##....######......##.......########..##.....##.##.....##.########..########..##.....##.##.##.##  =
                 =   .##.....##.##.....##.##..####.##....##.##.....##.##..####....##..........##.......##.....##.##.....##.##.....##.##...##...##.....##.##.....##.##..####  =
                 =   .##.....##.##.....##.##...###.##....##.##.....##.##...###....##..........##.......##.....##.##.....##.##.....##.##....##..##.....##.##.....##.##...###  =
                 =   .########...#######..##....##..######...#######..##....##....########....##.......########...#######...#######..##.....##.########...#######..##....##  =
                 =                                                                                                                                                           =
                 =============================================================================================================================================================
                                                                                  Projet C# 3 éme année ENIGMA

                                                                                            


                                                                                




                                                                                                                  
                                                                                                                                        Appuyez sur Entrée pour continuer...
");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine(@"


                    ===============================================
                    =                                             =
                    =   .##.....##.########.##....##.##.....##    =
                    =   .###...###.##.......###...##.##.....##    =
                    =   .####.####.##.......####..##.##.....##    =
                    =   .##.###.##.######...##.##.##.##.....##    =
                    =   .##.....##.##.......##..####.##.....##    =
                    =   .##.....##.##.......##...###.##.....##    =
                    =   .##.....##.########.##....##..#######.    =
                    =                                             =
                    ===============================================


");
                Console.Write("\nMenu : \n\n1 - Voyager\n\n2 - Aller au centre-ville\n\n3 - Voir mon équipement\n\n4 - Quitter\n");
                string userGlobalMenuPickStrigified = Console.ReadLine();
                int userGlobalMenuPick;

                if (!int.TryParse(userGlobalMenuPickStrigified, out userGlobalMenuPick))
                {
                    userChoiceErrorMessage();
                    continue;
                }

                switch (userGlobalMenuPick)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Vers quelle contrée voulez-vous voyager ?"); // Will do
                        Console.ReadKey();
                        break;
                    case 2:
                        bool inBuilding = true;
                        do
                        {
                            inBuilding = inBuildingProcess();
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
                        Console.WriteLine(@"
                        
                 =============================================================================================================================================================
                 =                                                                                                                                                           =        
                 =   .########...#######..##....##.......##..#######..##....##....########.########....########...#######..##.....##.########..########...#######..##....##  =
                 =   .##.....##.##.....##.###...##.......##.##.....##.###...##....##..........##.......##.....##.##.....##.##.....##.##.....##.##.....##.##.....##.###...##  =
                 =   .##.....##.##.....##.####..##.......##.##.....##.####..##....##..........##.......##.....##.##.....##.##.....##.##.....##.##.....##.##.....##.####..##  =
                 =   .##.....##.##.....##.##.##.##.......##.##.....##.##.##.##....######......##.......########..##.....##.##.....##.########..########..##.....##.##.##.##  =
                 =   .##.....##.##.....##.##..####.##....##.##.....##.##..####....##..........##.......##.....##.##.....##.##.....##.##...##...##.....##.##.....##.##..####  =
                 =   .##.....##.##.....##.##...###.##....##.##.....##.##...###....##..........##.......##.....##.##.....##.##.....##.##....##..##.....##.##.....##.##...###  =
                 =   .########...#######..##....##..######...#######..##....##....########....##.......########...#######...#######..##.....##.########...#######..##....##  =
                 =                                                                                                                                                           =
                 =============================================================================================================================================================
                                                                                  Projet C# 3 eme année ENIGMA

                                                                                            


                                                                                




                                                                                                                  
                                                                                                                                        Appuyez sur Entrée pour quitter...
");
                        Console.ReadKey();
                        break;
                    default:
                        userChoiceErrorMessage();
                        break;
                }
            } while (isOn);
        }

        static void userChoiceErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("T'es trop bourré pour marcher droit ou quoi ??");
            Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
            Console.ReadKey();
        }

        static bool inBuildingProcess()
        {
            Console.Clear();
            Console.Write("Vous vous retrouvez face à deux bâtiments, dans lequel rentrez-vous :\n\n1 - Entrer dans le magasin\n\n2 - Entrer dans l'auberge de la flûte étincellante\n\n3 - Retour vers l'entrée du village\n");

            string userBuildingMenuPickStringified = Console.ReadLine();
            int userBuildingMenuPick;

            if (!int.TryParse(userBuildingMenuPickStringified, out userBuildingMenuPick))
            {
                userChoiceErrorMessage();
                return true;
            }

            switch (userBuildingMenuPick)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Vous êtes dans le magasin."); // Will do
                    Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Vous êtes dans l'auberge de la flûte étincellante."); // Will do
                    Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                    Console.ReadKey();
                    break;
                case 3:
                    return false;
                default:
                    userChoiceErrorMessage();
                    break;
            }
            return true;
        }
    }
}



/* 
                                        
                                                  __
                                                .d$$b
                                              .' TO$;\
                                             /  : TP._;
                                            / _.;  :Tb|
                                           /   /   ;j$j
                                       _.-""       d$$$$
                                     .' ..       d$$$$;
                                    /  /P'      d$$$$P. |\
                                   /   ""      .d$$$P' |\^""l
                                 .'           `T$P^""""""""""  :
                             ._.'      _.'                ;
                          `-.-"".-'-' ._.       _.-""    .-""
                        `.-"" _____  ._              .-""
                       -(.g$$$$$$$b.              .'
                         """"^^T$$$P^)            .(:
                           _/  -""  /.'         /:/;
                        ._.'-'`-'  "")/         /;/;
                     `-.-""..--""""   "" /         /  ;
                    .-"" ..--""""        -'          :
                    ..--""""--.-""         (\      .-(\
                      ..--""""              `-\(\/;`
                        _.                      :
                                                ;`-
                                               :\
                                               ; 




 
 */