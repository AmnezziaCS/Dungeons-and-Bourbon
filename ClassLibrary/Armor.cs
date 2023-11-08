namespace ClassLibrary
{
    public class Armor: Item, IReturnItemAsString
    {
        public int GivenHealth { get; set; }

        /// <summary>
        /// EF constructor
        /// </summary>
        public Armor(): base()
        { }

        public string returnItemAsString()
        {
            return $"[{Name}] - ${Price} : +{GivenHealth} passive health in combat";
        }
    }
}
