namespace ClassLibrary
{
    internal class Armor: Item
    {
        private int _givenHealth;

        public int GivenHealth { get => _givenHealth; set => _givenHealth = value; }

        public Armor(int givenHealth, string name, int price) : base(name, price)
        {
            GivenHealth = givenHealth;
        }
    }
}
