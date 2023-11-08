using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Item
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Item()
        { }
    }
}
