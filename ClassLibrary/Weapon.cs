namespace ClassLibrary
{
    public class Weapon: Item, IReturnItemAsString
    {
        private int _givenDamage;

        public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }

        public Weapon(int givenDamage, string name, int price, int id, Player currentAssignedPlayer, int currentAssignedPlayerId) : base(id, name, price)
        {
            _givenDamage = givenDamage;
        }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Weapon() : base()
        { }

        public string returnItemAsString()
        {
            return $"[{Name}] - ${Price} : +{GivenDamage} passive damage in combat";
        }
    }
}
