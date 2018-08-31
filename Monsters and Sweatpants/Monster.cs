using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public class Monster
    {
        public virtual int Health { get; set; }
        public virtual int Strength { get; set; }
        public virtual double Defense { get; set; }

        protected Random r = new Random();
        protected int generatePlayerNumber => r.Next(0, 2);
        protected double generateDefenseAbility => r.NextDouble();


        public void PickPlayerToAttack(Player user, Player computer)
        {
            int previousUserAttacked = 0;
            int monsterChoice = r.Next(0, 1);
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
                    previousUserAttacked = 0;
                    break;
            }

            switch (previousUserAttacked)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("The monster is attacking your oponent");
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
                Console.WriteLine(Health);
                DecreaseMonsterHealth(playerStrength);
                Console.WriteLine(Health);
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
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Defense: " + Defense);
            Console.WriteLine("Health: " + Health);
        }

        public void DecreaseMonsterHealth(int playerStrength)
        {
            Health -= playerStrength;
        }
         
    }
}
