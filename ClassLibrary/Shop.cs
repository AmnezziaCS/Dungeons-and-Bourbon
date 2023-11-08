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

        public void buyItem(int itemIndex, Player player)
        {
            Item boughtItem = this.ItemList[itemIndex];
            
            if((Weapon)boughtItem != null)
            {
                Weapon weapon = (Weapon)boughtItem;
                player.Weapon = weapon;
            } else
            {
                Armor armor = (Armor)boughtItem;
                player.Armor = armor;
            }

            player.TotalGold -= boughtItem.Price;
            this.ItemList.RemoveAt(itemIndex);      
        }
    }
}
