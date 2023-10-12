namespace ClassLibrary
{
    internal class Weapon: Item
    {
        private int _givenDamage;

        public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }

        public Weapon(int givenDamage, string name, int price) : base(name, price)
        {
            _givenDamage = givenDamage;
        }
    }
}
