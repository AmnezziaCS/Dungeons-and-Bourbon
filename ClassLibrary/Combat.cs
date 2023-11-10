namespace ClassLibrary
{
    public class Combat
    {
        public string Status { get; set; }
        public Player Player { get; set; }
        public Stage Stage { get; set; }
        public int CurrentPlayerHealth { get; set; }
        public int CurrentMonsterIndex { get; set; }
        public int CurrentMonsterHealth { get; set; }

        public Combat(Player player, Stage stage)
        {
            Status = "ongoing";
            CurrentPlayerHealth = player.Health + player.Armor.GivenHealth;
            Stage = stage;
            Player = player;
            CurrentMonsterIndex = 0;
            CurrentMonsterHealth = Stage.MonsterList[CurrentMonsterIndex].Health;
        }

        public void NextTurn()
        {
            Monster currentMonster = Stage.MonsterList[CurrentMonsterIndex];
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
                    CurrentMonsterHealth -= playerAttack;
                    Console.WriteLine($"{currentMonster.Name} a {CurrentMonsterHealth} points de vie");
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
                    CurrentMonsterHealth -= playerAttack;
                    Console.WriteLine($"{currentMonster.Name} a {CurrentMonsterHealth} points de vie");
                }

                bool placeHolder = checkIfTurnHasEndedEarly(currentMonster);
            }
        }

        private bool checkIfTurnHasEndedEarly(Monster currentMonster)
        {
            if (CurrentMonsterHealth <= 0)
            {
                CurrentMonsterIndex++;
                Console.WriteLine($"{currentMonster.Name} a été vaincu");
                if (CurrentMonsterIndex >= Stage.MonsterList.Count)
                {
                    Status = "victory";
                    Console.WriteLine($"Tout les monstres du stage {Stage.Name} ont été vaincus, vous gagnez {Stage.RewardedXP}XP et ${Stage.RewardedGold} !");
                    if (Player.MaximumStageReached <= Stage.Id)
                    {
                        Console.WriteLine("Le stage suivant a été débloqué !");
                    }
                    return true;
                }
                CurrentMonsterHealth = Stage.MonsterList[CurrentMonsterIndex].Health;
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