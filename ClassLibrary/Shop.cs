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
                }
                if (item is Armor) 
                {
                    Armor armor = (Armor)item;
                    Console.WriteLine($"{itemIndex} - {armor.returnItemAsString()}");
                }
                if (item is ConsumableStatUpItem)
                {
                    ConsumableStatUpItem consumableStatUpItem = (ConsumableStatUpItem)item;
                    Console.WriteLine($"{itemIndex} - {consumableStatUpItem.returnItemAsString()}");
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
                this.ItemList.RemoveAt(itemIndex);
            }
            if (boughtItem is Armor)
            {
                Armor armor = (Armor)boughtItem;
                if (player.Armor.GivenHealth > armor.GivenHealth)
                {
                    Console.WriteLine("Vous avez déjà une armure plus puissante !");
                    return;
                }
                player.Armor = armor;
                this.ItemList.RemoveAt(itemIndex);
            }
            if (boughtItem is ConsumableStatUpItem)
            {
                ConsumableStatUpItem consumableStatUpItem = (ConsumableStatUpItem)boughtItem;
                if (player.ConsumableStatUpItem != null)
                {
                    Console.WriteLine("Vous avez déjà un objet consommable !");
                    return;
                }
                player.ConsumableStatUpItem = consumableStatUpItem;
            }

            player.TotalGold -= boughtItem.Price;
            Console.WriteLine($"Vous avez acheté : {boughtItem.Name}!");
        }
    }
}
