namespace ClassLibrary
{
    public class ConsumableStatUpItem: Item
    {
        private int _givenDamage;
        private int _givenHealth;
        private int _givenSpeed;
        private int _givenLuck;

        public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }
        public int GivenHealth { get => _givenHealth; set => _givenHealth = value; }
        public int GivenSpeed { get => _givenSpeed; set => _givenSpeed = value; }
        public int GivenLuck { get => _givenLuck; set => _givenLuck = value; }

        public ConsumableStatUpItem(int givenDamage, int givenHealth, int givenSpeed, int givenLuck, string name, int price) : base(name, price)
        {
            GivenDamage = givenDamage;
            GivenHealth = givenHealth;
            GivenSpeed = givenSpeed;
            GivenLuck = givenLuck;
        }
    }
}
