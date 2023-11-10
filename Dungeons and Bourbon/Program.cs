using Dungeons_and_Bourbon;

namespace Dungeon_Bourbon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContextHelper.initializeContext();

            using (var db = new GameContext())
            {
                Menu.renderMenu(db);  
            }
        }
    }
}