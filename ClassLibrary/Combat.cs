namespace ClassLibrary
{
    public class Combat
    {
        private string _status;
        private Player _player;
        private Stage _stage;
        private int _currentPlayerHealth;
        private List<Monster> _remainingMonstersList;

        public string Status { get => _status; set => _status = value; }
        public int CurrentPlayerHealth { get => _currentPlayerHealth; set => _currentPlayerHealth = value; }
        public Player Player { get => _player; set => _player = value; }
        public Stage Stage { get => _stage; set => _stage = value; }
        public List<Monster> RemainingMonstersList { get => _remainingMonstersList; set => _remainingMonstersList = value; }

        public Combat(Player player, Stage stage)
        {
            Status = "ongoing";
            CurrentPlayerHealth = player.Health + player.Armor.GivenHealth;
            Stage = stage;
            Player = player;
            RemainingMonstersList = stage.MonsterList;
        }

        public void NextTurn()
        {
            Monster currentMonster = RemainingMonstersList[0];
            char playerPick;
            do
            {
                Console.WriteLine("(a) pour attaquer");
                playerPick = Console.ReadKey().KeyChar;
            } while (playerPick != 'a'); // Will change when consumable items are implemented

            if (playerPick == 'a')
            {
                Console.Clear();
                bool isPlayerFaster = Player.Speed >= currentMonster.Speed;
                int playerAttack = Player.attack(); // Will pass potential damage buff here when implemented
                int monsterAttack = currentMonster.attack();
                if (isPlayerFaster)
                {
                    currentMonster.Health -= playerAttack;
                    Console.WriteLine($"{currentMonster.Name} a {currentMonster.Health} points de vie");
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    CurrentPlayerHealth -= monsterAttack;
                    Console.WriteLine($"Il vous reste {CurrentPlayerHealth} points de vie");
                } else
                {
                    CurrentPlayerHealth -= monsterAttack;
                    Console.WriteLine($"Il vous reste {CurrentPlayerHealth} points de vie");
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    currentMonster.Health -= playerAttack;
                    Console.WriteLine($"{currentMonster.Name} a {currentMonster.Health} points de vie");
                }

                bool placeHolder = checkIfTurnHasEndedEarly(currentMonster);
            }
        }

        private bool checkIfTurnHasEndedEarly(Monster currentMonster)
        {
            if (currentMonster.Health <= 0)
            {
                RemainingMonstersList.Remove(currentMonster);
                Console.WriteLine($"{currentMonster.Name} a été vaincu");
                if (RemainingMonstersList.Count == 0)
                {
                    Status = "victory";
                    Console.WriteLine($"Tout les monstres du stage {Stage.Name} ont été vaincus, vous gagnez {Stage.RewardedXP}XP et ${Stage.RewardedGold} !");
                    if (Player.MaximumStageReached <= Stage.Id)
                    {
                        Console.WriteLine("Le stage suivant a été débloqué !");
                    }
                }
                return true;
            }
            if (CurrentPlayerHealth <= 0)
            {
                Status = "defeat";
                Console.WriteLine("Vous avez été vaincu");
                return true;
            }
            return false;
        }
    }
}