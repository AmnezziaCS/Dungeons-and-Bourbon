namespace ClassLibrary
{
    public class Item
    {
        private int _id;
        private string _name;
        private int _price;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get => _name; set => _name = value; }
        public int Price { get => _price; set => _price = value; }

        public Item(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Item()
        { }
    }
}
