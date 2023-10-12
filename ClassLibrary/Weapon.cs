namespace ClassLibrary
{
    public class Weapon: Item, IReturnItemAsString
    {
        private int _givenDamage;

        public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }

        public Weapon(int givenDamage, string name, int price) : base(name, price)
        {
            _givenDamage = givenDamage;
        }

        public string returnItemAsString()
        {
            return $"[{Name}] - ${Price} : +{GivenDamage} passive damage in combat";
        }
    }
}
