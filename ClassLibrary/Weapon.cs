namespace ClassLibrary
{
    public class Weapon: Item
    {
        public int GivenDamage { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Weapon() : base()
        { }

        new public string returnItemAsString()
        {
            return $"[{this.Name}] - ${this.Price} : +{this.GivenDamage} passive damage in combat";
        }
    }
}
