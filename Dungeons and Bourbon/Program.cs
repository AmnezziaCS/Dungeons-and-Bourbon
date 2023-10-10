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
            bool IsOn = true;

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

                                                                                            


                                                                                




                                                                                                                  
                                                                                                                                        Appuyez sur Entrée pour continuer...
");
            Console.ReadKey();

            while (IsOn == true)
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
                Console.WriteLine("\nMenu : ");
                Console.WriteLine("\n1 - Voyager");
                Console.WriteLine("\n2 - Aller au centre-ville");
                Console.WriteLine("\n3 - Voir mon équipement");
                Console.WriteLine("\n4 - Quitter");
                string input = Console.ReadLine();
                int choix;
                bool isChoixOk = false;

                do
                {
                    if (int.TryParse(input, out choix))
                    {
                        switch (choix)
                        {
                            case 1:
                                isChoixOk = true;
                                Console.Clear();
                                Console.WriteLine("Vers quelle contrée voulez-vous voyager ?");
                                Console.ReadKey();
                                break;
                            case 2:
                                bool inBuilding = true;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vous vous retrouvez face à deux bâtiments, dans lequel rentrez-vous : ");
                                    Console.WriteLine("\n1 - Entrer dans le magasin");
                                    Console.WriteLine("\n2 - Entrer dans l'auberge de la flûte étincellante");
                                    Console.WriteLine("\n3 - Retour vers l'entrée du village");

                                    string buildingInput = Console.ReadLine();
                                    int buildingChoice;

                                    if (int.TryParse(buildingInput, out buildingChoice))
                                    {
                                        switch (buildingChoice)
                                        {
                                            case 1:
                                                isChoixOk = true;
                                                Console.Clear();
                                                Console.WriteLine("Vous êtes dans le magasin.");
                                                Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                isChoixOk = true;
                                                Console.Clear();
                                                Console.WriteLine("Vous êtes dans l'auberge de la flûte étincellante.");
                                                Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                isChoixOk = true;
                                                inBuilding = false;
                                                break;
                                            default:
                                                isChoixOk = true;
                                                Console.Clear();
                                                Console.WriteLine("Choix invalide.");
                                                Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("T'es trop bourré pour marcher droit ou quoi ??");
                                        Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                                        Console.ReadKey();
                                    }
                                } while (inBuilding);
                                break;
                            case 3:
                                isChoixOk = true;
                                Console.Clear();
                                Console.WriteLine("Voir mon équipement :");
                                Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
                                Console.ReadKey();
                                break;
                            case 4:
                                isChoixOk = true;
                                Console.Clear();
                                Console.WriteLine("Voulez vous vraiment quiter ce monde merveilleux ? êtes vous bien passé aux toilettes avant de vous endormir ?");
                                Console.WriteLine("\n1 - Oui");
                                Console.WriteLine("\n2 - Non");
                                string confirmation = Console.ReadLine();
                                int choixConfirmation;

                                if (int.TryParse(confirmation, out choixConfirmation))
                                {
                                    switch (choixConfirmation)
                                    {
                                        case 1:
                                            IsOn = false;
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
                                        case 2:
                                            Console.WriteLine("Retour au menu principal...");
                                            Console.ReadKey();
                                            break;
                                        default:
                                            Console.WriteLine("Choix invalide. Retour au menu principal...");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Choix invalide. Retour au menu principal...");
                                    Console.ReadKey();
                                }
                                break;


                            default:
                                Console.Clear();
                                Console.WriteLine("Choix invalide.");
                                Console.ReadKey();
                                isChoixOk = false;
                                break;
                        }
                    }
                    else if (isChoixOk == false)
                    {
                        Console.Clear();
                        Console.WriteLine("T'es trop bourré pour marcher droit ou quoi ??.  [Appuyer sur Entrée ...]");
                        Console.ReadKey();
                        break;
                    }
                } while (isChoixOk == false);
            }
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