namespace ClassLibrary
{
    public class Weapon: Item, IReturnItemAsString
    {
        public int GivenDamage { get; set; }

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
