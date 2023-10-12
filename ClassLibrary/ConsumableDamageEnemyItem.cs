namespace ClassLibrary
{
    internal class ConsumableDamageEnemyItem: Item
    {
        private int _damage;

        public int Damage { get => _damage; set => _damage = value; }

        public ConsumableDamageEnemyItem(int damage, string name, int price) : base(name, price)
        {
            Damage = damage;
        }
    }
}
