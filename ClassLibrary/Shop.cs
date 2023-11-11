using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Shop
    {
        [Key]
        public int Id { get; private set; }
        public List<Item> ItemList { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Shop()
        { }

        public void renderItemList()
        {
            int itemIndex = 1;
            foreach (Item item in this.ItemList)
            {
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;
                    Console.WriteLine($"{itemIndex} - {weapon.returnItemAsString()}");
                } else
                {
                    Armor armor = (Armor)item;
                    Console.WriteLine($"{itemIndex} - {armor.returnItemAsString()}");
                }
                itemIndex++;
            }
        }

        public void buyItem(int itemIndex, Player player)
        {
            Item boughtItem = this.ItemList[itemIndex];
            
            if(boughtItem is Weapon)
            {
                Weapon weapon = (Weapon)boughtItem;
                if (player.Weapon.GivenDamage > weapon.GivenDamage)
                {
                    Console.WriteLine("Vous avez déjà une arme plus puissante !");
                    return;
                }
                player.Weapon = weapon;
            } else
            {
                Armor armor = (Armor)boughtItem;
                if (player.Armor.GivenHealth > armor.GivenHealth)
                {
                    Console.WriteLine("Vous avez déjà une armure plus puissante !");
                    return;
                }
                player.Armor = armor;
            }

            player.TotalGold -= boughtItem.Price;
            this.ItemList.RemoveAt(itemIndex);      
        }
    }
}
