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

        public void nextTurn()
        {
            Monster currentMonster = Stage.MonsterList[CurrentMonsterIndex];
            char playerPick;
            do
            {
                Console.WriteLine("\n(a) pour attaquer");
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
                    displayHealthBar(currentMonster.Name, Stage.MonsterList[CurrentMonsterIndex].Health, CurrentMonsterHealth);
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    CurrentPlayerHealth -= monsterAttack;
                    displayHealthBar("Joueur", Player.Health + Player.Armor.GivenHealth , CurrentPlayerHealth);
                } else
                {
                    CurrentPlayerHealth -= monsterAttack;
                    displayHealthBar("Joueur", Player.Health + Player.Armor.GivenHealth, CurrentPlayerHealth);
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    CurrentMonsterHealth -= playerAttack;
                    displayHealthBar(currentMonster.Name, Stage.MonsterList[CurrentMonsterIndex].Health, CurrentMonsterHealth);
                }

                bool placeHolder = checkIfTurnHasEndedEarly(currentMonster);
            }
        }

        private bool checkIfTurnHasEndedEarly(Monster currentMonster)
        {
            if (CurrentMonsterHealth <= 0)
            {
                CurrentMonsterIndex++;
                Console.Clear();
                Console.WriteLine($"{currentMonster.Name} a été vaincu");
                if (CurrentMonsterIndex >= Stage.MonsterList.Count)
                {
                    Status = "victory";
                    Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Vous avez été vaincu");
                return true;
            }
            return false;
        }

        private void displayHealthBar(string entitieName, int initialHealth, int currentHealth)
        {
            // Calculer le pourcentage de vie restante
            double healthPercent = Math.Max(0, (double)currentHealth / initialHealth * 100);

            // Afficher la barre de vie
            Console.WriteLine($"\nEntité : {entitieName}");
            Console.WriteLine($"Vie : {currentHealth} / {initialHealth}");
            Console.WriteLine("Barre de vie : [" + new string('#', (int)healthPercent / 5) + new string('-', 20 - (int)healthPercent / 5) + "]");
        }
    }
}