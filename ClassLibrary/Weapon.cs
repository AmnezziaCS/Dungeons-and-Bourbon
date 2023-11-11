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
            return $"[{Name}] - ${Price} : +{GivenDamage} passive damage in combat";
        }
    }
}
