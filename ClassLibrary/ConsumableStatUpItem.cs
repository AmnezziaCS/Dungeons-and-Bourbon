namespace ClassLibrary
{
    public class ConsumableStatUpItem: Item
    {
        public int GivenDamage { get; set; }
        public int GivenHealth { get; set; }

        new public string returnItemAsString()
        {
            return $"[{Name}] - ${Price} : donne {GivenDamage} de dégâts et {GivenHealth} de vie";
        }
    }
}
