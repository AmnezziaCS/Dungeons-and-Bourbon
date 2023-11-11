namespace ClassLibrary
{
    public class Armor: Item
    {
        public int GivenHealth { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Armor(): base()
        { }

        new public string returnItemAsString()
        {
            return $"[{this.Name}] - ${this.Price} : +{this.GivenHealth} passive health in combat";
        }
    }
}
