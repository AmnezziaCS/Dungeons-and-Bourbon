namespace ClassLibrary
{
    internal class Combat
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
            CurrentPlayerHealth = player.Health + player.CurrentArmor.GivenHealth;
            Stage = stage;
            Player = player;
            RemainingMonstersList = new List<Monster>(stage.MonsterArray);
        }

        public void NextTurn()
        {
            Monster currentMonster = RemainingMonstersList[0];
            char playerPick;
            do
            {
                playerPick = Console.ReadKey().KeyChar;
            } while (playerPick != 'a'); // Will change when consumable items are implemented

            if (playerPick == 'a')
            {
                bool isPlayerFaster = Player.Speed >= currentMonster.Speed;
                int playerAttack = Player.attack(); // Will pass potential damage buff here when implemented
                int monsterAttack = currentMonster.attack();
                if (isPlayerFaster)
                {
                    currentMonster.Health -= playerAttack;
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    CurrentPlayerHealth -= monsterAttack;
                } else
                {
                    CurrentPlayerHealth -= monsterAttack;
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    currentMonster.Health -= playerAttack;
                }

                bool placeHolder = checkIfTurnHasEndedEarly(currentMonster);
            }
            
        }

        private bool checkIfTurnHasEndedEarly(Monster currentMonster)
        {
            if (currentMonster.Health <= 0)
            {
                RemainingMonstersList.Remove(currentMonster);
                return true;
            }
            if (CurrentPlayerHealth <= 0)
            {
                Status = "defeat";
                return true;
            }
            if (RemainingMonstersList.Count == 0)
            {
                Status = "victory";
                return true;
            }
            return false;
        }
    }
}
