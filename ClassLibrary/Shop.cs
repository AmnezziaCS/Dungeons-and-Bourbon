using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Shop
    {
        private List<Item> _itemList;

        public List<Item> ItemList { get => _itemList; set => _itemList = value; }

        public Shop(List<Item> itemList)
        {
            ItemList = itemList;
        }

        public void buyItem(int itemIndex, Player player)
        {
            Item boughtItem = this.ItemList[itemIndex];
            player.addItemToInventory(boughtItem);
            player.TotalGold -= boughtItem.Price;
            this.ItemList.RemoveAt(itemIndex);      
        }
    }
}
