namespace Dungeons_and_Bourbon
{
    public class Utils
    {
        public static string getASCIIArt(string fileName)
        {
            string titleASCIIPath = $"./Ressources/{fileName}.txt";
            return File.ReadAllText(titleASCIIPath);
        }

        public static void userChoiceErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("T'es trop bourré pour marcher droit ou quoi ??");
            Console.WriteLine("[Appuyez sur Entrée pour continuer...]");
            Console.ReadKey();
        }
    }
}
