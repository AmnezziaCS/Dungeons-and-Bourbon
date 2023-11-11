namespace ClassLibrary
{
    public class ConsumableStatUpItem: Item
    {
        public int GivenDamage { get; set; }
        public int GivenHealth { get; set; }

        new public string returnItemAsString()
        {
            return $"[{this.Name}] - ${this.Price} : donne {this.GivenDamage} de dégâts et {this.GivenHealth} de vie";
        }
    }
}
