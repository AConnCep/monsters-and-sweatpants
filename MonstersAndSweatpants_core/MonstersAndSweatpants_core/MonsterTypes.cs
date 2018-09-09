using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    class GoblinOfGoo : IMonsterable
    {
        public int Health { get; set; } = 250;
        public int Strength { get; set; } = 5;
        public double Defense { get; set; } = 0.2;

        public GoblinOfGoo()
        {
            Console.WriteLine("A Goblin of Goo approaches!");
            PrintMonsterStats();
        }
        

        protected Random r = new Random();
        protected int generatePlayerNumber => r.Next(0, 2);
        protected double generateDefenseAbility => r.NextDouble();


        public void PickPlayerToAttack(Player user, Player computer)
        {
            int previousUserAttacked = 0;
            int monsterChoice = r.Next(0, 2);
            switch (monsterChoice)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you first");
                    Attack(user);
                    previousUserAttacked = 0;
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent first");
                    Attack(computer);
                    previousUserAttacked = 1;
                    break;
            }

            switch (previousUserAttacked)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent");
                    Attack(computer);
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you");
                    Attack(user);
                    break;
            }
        }

        public void Attack(Player player)
        {
            player.Defend(Strength);

        }

        public bool Defend(int playerStrength)
        {
            // chance of monster defending successfully
            if (generateDefenseAbility < Defense)
            {
                //Console.WriteLine("The monster deflects your shot and sustains no damage.");
                return true;
            }
            else
            {
                //Console.WriteLine("The monster has been hit! He loses " + playerStrength + " HP!");
                DecreaseMonsterHealth(playerStrength);
                //Console.WriteLine(Health);

                return false;
            }
        }

        public void PrintMonsterHealth()
        {
            Console.WriteLine("The monster has " + Health + " HP remaining");
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine("Strength: " + Strength + " HP");
            Console.WriteLine("Defense: " + (Defense * 100) + "% chance of deflect");
            Console.WriteLine("Health: " + Health + " HP");
        }

        public void DecreaseMonsterHealth(int playerStrength)
        {
            Health -= playerStrength;
            if (Health <= 0)
            {
                throw new MonsterDiedException();
            }
        }

    }

    class TrollOfTribulation : IMonsterable
    {
        public TrollOfTribulation()
        {
            Console.WriteLine("A Troll of Tribulation approaches!");
            PrintMonsterStats();
        }
        public int Health { get; set; } = 350;
        public int Strength { get; set; } = 10;
        public double Defense { get; set; } = 0.4;

        protected Random r = new Random();
        protected int generatePlayerNumber => r.Next(0, 2);
        protected double generateDefenseAbility => r.NextDouble();


        public void PickPlayerToAttack(Player user, Player computer)
        {
            int previousUserAttacked = 0;
            int monsterChoice = r.Next(0, 2);
            switch (monsterChoice)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you first");
                    Attack(user);
                    previousUserAttacked = 0;
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent first");
                    Attack(computer);
                    previousUserAttacked = 1;
                    break;
            }

            switch (previousUserAttacked)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent");
                    Attack(computer);
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you");
                    Attack(user);
                    break;
            }
        }

        public void Attack(Player player)
        {
            player.Defend(Strength);

        }

        public bool Defend(int playerStrength)
        {
            // chance of monster defending successfully
            if (generateDefenseAbility < Defense)
            {
                //Console.WriteLine("The monster deflects your shot and sustains no damage.");
                return true;
            }
            else
            {
                //Console.WriteLine("The monster has been hit! He loses " + playerStrength + " HP!");
                DecreaseMonsterHealth(playerStrength);
                //Console.WriteLine(Health);

                return false;
            }
        }

        public void PrintMonsterHealth()
        {
            Console.WriteLine("The monster has " + Health + " HP remaining");
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine("Strength: " + Strength + " HP");
            Console.WriteLine("Defense: " + (Defense * 100) + "% chance of deflect");
            Console.WriteLine("Health: " + Health + " HP");
        }

        public void DecreaseMonsterHealth(int playerStrength)
        {
            Health -= playerStrength;
            if (Health <= 0)
            {
                throw new MonsterDiedException();
            }
        }

    }

    class OrcOfOrdeal : IMonsterable
    {
        public OrcOfOrdeal()
        {
            Console.WriteLine("An Orc of Ordeal approaches!");
            PrintMonsterStats();
        }
        public int Health { get; set; } = 500;
        public int Strength { get; set; } = 15;
        public double Defense { get; set; } = 0.6;

        protected Random r = new Random();
        protected int generatePlayerNumber => r.Next(0, 2);
        protected double generateDefenseAbility => r.NextDouble();


        public void PickPlayerToAttack(Player user, Player computer)
        {
            int previousUserAttacked = 0;
            int monsterChoice = r.Next(0, 2);
            switch (monsterChoice)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you first");
                    Attack(user);
                    previousUserAttacked = 0;
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent first");
                    Attack(computer);
                    previousUserAttacked = 1;
                    break;
            }

            switch (previousUserAttacked)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent");
                    Attack(computer);
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you");
                    Attack(user);
                    break;
            }
        }

        public void Attack(Player player)
        {
            player.Defend(Strength);

        }

        public bool Defend(int playerStrength)
        {
            // chance of monster defending successfully
            if (generateDefenseAbility < Defense)
            {
                //Console.WriteLine("The monster deflects your shot and sustains no damage.");
                return true;
            }
            else
            {
                //Console.WriteLine("The monster has been hit! He loses " + playerStrength + " HP!");
                DecreaseMonsterHealth(playerStrength);
                //Console.WriteLine(Health);

                return false;
            }
        }

        public void PrintMonsterHealth()
        {
            Console.WriteLine("The monster has " + Health + " HP remaining");
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine("Strength: " + Strength + " HP");
            Console.WriteLine("Defense: " + (Defense * 100) + "% chance of deflect");
            Console.WriteLine("Health: " + Health + " HP");
        }

        public void DecreaseMonsterHealth(int playerStrength)
        {
            Health -= playerStrength;
            if (Health <= 0)
            {
                throw new MonsterDiedException();
            }
        }
    }

    class DragonOfDeath : IMonsterable
    {
        public DragonOfDeath()
        {
            Console.WriteLine("A Dragon of Death approaches!");
            PrintMonsterStats();
        }
        public int Health { get; set; } = 650;
        public int Strength { get; set; } = 20;
        public double Defense { get; set; } = 0.7;

        protected Random r = new Random();
        protected int generatePlayerNumber => r.Next(0, 2);
        protected double generateDefenseAbility => r.NextDouble();


        public void PickPlayerToAttack(Player user, Player computer)
        {
            int previousUserAttacked = 0;
            int monsterChoice = r.Next(0, 2);
            switch (monsterChoice)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you first");
                    Attack(user);
                    previousUserAttacked = 0;
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent first");
                    Attack(computer);
                    previousUserAttacked = 1;
                    break;
            }

            switch (previousUserAttacked)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your opponent");
                    Attack(computer);
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking you");
                    Attack(user);
                    break;
            }
        }

        public void Attack(Player player)
        {
            player.Defend(Strength);

        }

        public bool Defend(int playerStrength)
        {
            // chance of monster defending successfully
            if (generateDefenseAbility < Defense)
            {
                //Console.WriteLine("The monster deflects your shot and sustains no damage.");
                return true;
            }
            else
            {
                //Console.WriteLine("The monster has been hit! He loses " + playerStrength + " HP!");
                DecreaseMonsterHealth(playerStrength);
                //Console.WriteLine(Health);

                return false;
            }
        }

        public void PrintMonsterHealth()
        {
            Console.WriteLine("The monster has " + Health + " HP remaining");
        }

        public void PrintMonsterStats()
        {
            Console.WriteLine("Strength: " + Strength + " HP");
            Console.WriteLine("Defense: " + (Defense * 100) + "% chance of deflect");
            Console.WriteLine("Health: " + Health + " HP");
        }

        public void DecreaseMonsterHealth(int playerStrength)
        {
            Health -= playerStrength;
            if (Health <= 0)
            {
                throw new MonsterDiedException();
            }
        }
    }
}
