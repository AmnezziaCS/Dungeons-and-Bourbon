using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Entity() : base()
        { }
    }
}