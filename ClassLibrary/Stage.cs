using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Stage
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public int RewardedGold { get; set; }
        public int RewardedXP { get; set; }
        public List<Monster> MonsterList { get; set; } = new();
        
        /// <summary>
        /// EF constructor
        /// </summary>
        public Stage()
        { }
    }
}
