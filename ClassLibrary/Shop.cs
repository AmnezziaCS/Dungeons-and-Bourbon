namespace ClassLibrary
{
    public class Shop
    {
        private int _id { get; set; }
        private List<Item> _itemList;

        public int Id { get { return _id; } set { _id = value; } }
        public List<Item> ItemList { get => _itemList; set => _itemList = value; }

        public Shop(int id, List<Item> itemList)
        {
            Id = id;
            ItemList = itemList;
        }

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
                player.CurrentWeapon = weapon;
            } else
            {
                Armor armor = (Armor)boughtItem;
                player.CurrentArmor = armor;
            }

            player.TotalGold -= boughtItem.Price;
            this.ItemList.RemoveAt(itemIndex);      
        }
    }
}
