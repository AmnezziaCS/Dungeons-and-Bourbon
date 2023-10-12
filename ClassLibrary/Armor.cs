namespace ClassLibrary
{
    public class Armor: Item, IReturnItemAsString
    {
        private int _givenHealth;

        public int GivenHealth { get => _givenHealth; set => _givenHealth = value; }

        public Armor(int givenHealth, string name, int price) : base(name, price)
        {
            GivenHealth = givenHealth;
        }

        public string returnItemAsString()
        {
            return $"[{Name}] - ${Price} : +{GivenHealth} passive health in combat";
        }
    }
}
