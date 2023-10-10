namespace ClassLibrary
{
    public class Entity
    {
        private int _damage;
        private int _health;
        private int _speed;
        private int _luck;
        private string _name;

        public int Damage { get => _damage; set => _damage = value; }
        public int Health { get => _health; set => _health = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public int Luck { get => _luck; set => _luck = value; }
        public string Name { get => _name; set => _name = value; }

        public Entity(int damage, int health, int speed, int luck, string name)
        {
            Damage = damage;
            Health = health;
            Speed = speed;
            Luck = luck;
            Name = name;
        }
    }
}