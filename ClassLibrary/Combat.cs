namespace ClassLibrary
{
    public class Combat
    {
        public string Status { get; set; }
        public Player Player { get; set; }
        public Stage Stage { get; set; }
        public int CurrentPlayerHealth { get; set; }
        public int CurrentPlayerDamageBuff { get; set; }
        public int CurrentPlayerHealthBuff { get; set; }
        public int CurrentMonsterIndex { get; set; }
        public int CurrentMonsterHealth { get; set; }
        
        public Combat(Player player, Stage stage)
        {
            this.Status = "ongoing";
            this.Stage = stage;
            this.Player = player;

            this.CurrentPlayerHealth = player.Health + player.Armor.GivenHealth;
            this.CurrentPlayerDamageBuff = 0;
            this.CurrentPlayerHealthBuff = 0;

            this.CurrentMonsterIndex = 0;
            this.CurrentMonsterHealth = stage.MonsterList[CurrentMonsterIndex].Health;
        }

        public void nextTurn()
        {
            Monster currentMonster = Stage.MonsterList[CurrentMonsterIndex];
            string consumableNameBuffer = Player.ConsumableStatUpItem != null ? Player.ConsumableStatUpItem.Name : "Aucun conssomable possédé pour le moment";
            
            char playerPick;
            do
            {
                Console.WriteLine($" \n-- Buffs en cours [Vie: {this.CurrentPlayerHealthBuff} / Dégats: {this.CurrentPlayerDamageBuff}] --\n\nMenu de combat :\n - (a) pour attaquer\n - (i) pour utiliser votre item consommable ({consumableNameBuffer})");
                playerPick = Console.ReadKey().KeyChar;
            } while (playerPick != 'a' && playerPick != 'i');

            if (playerPick == 'a')
            {
                Console.Clear();
                bool isPlayerFaster = this.Player.Speed >= currentMonster.Speed;
                int playerAttack = this.Player.attack(this.CurrentPlayerDamageBuff);
                int monsterAttack = currentMonster.attack();
                if (isPlayerFaster)
                {
                    CurrentMonsterHealth -= playerAttack;
                    displayHealthBar(currentMonster.Name, this.Stage.MonsterList[CurrentMonsterIndex].Health, this.CurrentMonsterHealth);
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    this.CurrentPlayerHealth -= monsterAttack;
                    displayHealthBar("Joueur", this.Player.Health + this.Player.Armor.GivenHealth , this.CurrentPlayerHealth);
                } else
                {
                    this.CurrentPlayerHealth -= monsterAttack;
                    displayHealthBar("Joueur", this.Player.Health + this.Player.Armor.GivenHealth, this.CurrentPlayerHealth);
                    if (checkIfTurnHasEndedEarly(currentMonster))
                    {
                        return;
                    }
                    this.CurrentMonsterHealth -= playerAttack;
                    displayHealthBar(currentMonster.Name, this.Stage.MonsterList[CurrentMonsterIndex].Health, this.CurrentMonsterHealth);
                }

                bool placeHolder = checkIfTurnHasEndedEarly(currentMonster);
            }

            if (playerPick == 'i')
            {
                Console.Clear();
                this.CurrentPlayerHealth += this.Player.ConsumableStatUpItem.GivenHealth;
                this.CurrentPlayerHealthBuff += this.Player.ConsumableStatUpItem.GivenHealth;
                this.CurrentPlayerDamageBuff = this.Player.ConsumableStatUpItem.GivenDamage;
                this.Player.ConsumableStatUpItem = null;
            }
        }

        private bool checkIfTurnHasEndedEarly(Monster currentMonster)
        {
            if (this.CurrentMonsterHealth <= 0)
            {
                this.CurrentMonsterIndex++;
                Console.Clear();
                Console.WriteLine($"{currentMonster.Name} a été vaincu");
                if (this.CurrentMonsterIndex >= this.Stage.MonsterList.Count)
                {
                    this.Status = "victory";
                    Console.Clear();
                    Console.WriteLine(victoryASCIIString);
                    Console.WriteLine($"\nTous les monstres du stage {this.Stage.Name} ont été vaincus, vous gagnez {this.Stage.RewardedXP}XP et ${this.Stage.RewardedGold} !");
                    if (this.Player.MaximumStageReached == this.Stage.Id && this.Stage.Id != 15)
                    {
                        Console.WriteLine("\nLe stage suivant a été débloqué !");
                    }
                    return true;
                }
                this.CurrentMonsterHealth = this.Stage.MonsterList[this.CurrentMonsterIndex].Health;
                return true;
            }
            if (this.CurrentPlayerHealth <= 0)
            {
                this.Status = "defeat";
                Console.Clear();
                Console.WriteLine(defeatASCIIString);
                return true;
            }
            return false;
        }

        private void displayHealthBar(string entityName, int initialHealth, int currentHealth)
        {
            // Calculer le pourcentage de vie restante
            double healthPercent = Math.Max(0, (double)currentHealth / initialHealth * 100);

            // Afficher la barre de vie
            Console.WriteLine($"\nEntité : {entityName}");
            Console.WriteLine($"Vie : {currentHealth} / {initialHealth}");
            Console.WriteLine("Barre de vie : [" + new string('#', (int)healthPercent / 5) + new string('-', 20 - (int)healthPercent / 5) + "]");
        }

        public string defeatASCIIString = @"
          _______                   _        _______  _______  _______ 
|\     /|(  ___  )|\     /|        ( \      (  ___  )(  ____ \(  ____ \
( \   / )| (   ) || )   ( |        | (      | (   ) || (    \/| (    \/
 \ (_) / | |   | || |   | |        | |      | |   | || (_____ | (__    
  \   /  | |   | || |   | |        | |      | |   | |(_____  )|  __)   
   ) (   | |   | || |   | |        | |      | |   | |      ) || (      
   | |   | (___) || (___) |        | (____/\| (___) |/\____) || (____/\
   \_/   (_______)(_______)        (_______/(_______)\_______)(_______/
   
   ";

        public string victoryASCIIString = @"
|\     /|(  ___  )|\     /|        |\     /|\__   __/( (    /|
( \   / )| (   ) || )   ( |        | )   ( |   ) (   |  \  ( |
 \ (_) / | |   | || |   | |        | | _ | |   | |   |   \ | |
  \   /  | |   | || |   | |        | |( )| |   | |   | (\ \) |
   ) (   | |   | || |   | |        | || || |   | |   | | \   |
   | |   | (___) || (___) |        | () () |___) (___| )  \  |
   \_/   (_______)(_______)        (_______)\_______/|/    )_)
";
    }
}