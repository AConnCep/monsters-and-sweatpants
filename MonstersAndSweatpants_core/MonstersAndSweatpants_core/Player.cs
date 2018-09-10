using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public class Player
    {
        public virtual int Score { get; private set; } = 0;
        public virtual int Health { get; set; }
        public virtual int Strength { get; private set; }
        public virtual double Defense { get; private set; }

        public virtual List<AttackCard> playerAttackCards { get; private set; }
        public virtual List<DefenseCard> playerDefenseCards { get; private set; }

        public Random r = new Random();
        public double GenerateDefenseAbility() => r.NextDouble();

        public Player()
        {
            playerAttackCards = new List<AttackCard>();
            playerDefenseCards = new List<DefenseCard>();
        }
        public void GeneratePlayerCards()
        {
            for (int i = 0; i < 5; i++)
            {
                CardDealer.GenerateCard(this, CardDealer.CardType.AttackCard);
                CardDealer.GenerateCard(this, CardDealer.CardType.DefenseCard);
            }
        }

        public void ReportCards(CardDealer.CardType cardType)
        {
            Console.WriteLine();
            if (cardType == CardDealer.CardType.AttackCard)
            {
                Console.WriteLine("-Attack-");
                foreach (AttackCard aCard in playerAttackCards)
                {
                    Console.WriteLine(aCard.Name + " - " + aCard.Attack + " HP");
                }
            }
            else if (cardType == CardDealer.CardType.DefenseCard)
            {
                Console.WriteLine("-Defense-");
                foreach (DefenseCard dCard in playerDefenseCards)
                {
                    Console.WriteLine(dCard.Name + " - " + (dCard.Defense * 100) + "% chance of deflect");
                }
            }
        }

        public virtual void MountCard(AttackCard card)
        {
            Strength = card.Attack;
            Defense = 0.10;
            playerAttackCards.Remove(card);
        }

        public virtual void MountCard(DefenseCard card)
        {
            Defense = card.Defense;
            Strength = 1;
            playerDefenseCards.Remove(card);
        }

        public virtual bool ChooseAttackCard()
        {
            Console.WriteLine();
            if (playerAttackCards.Count > 0)
            {
                Console.WriteLine("Please select an attack card to mount");
                for (int i = 0; i < playerAttackCards.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + playerAttackCards[i].Name + " - " + playerAttackCards[i].Attack + " HP");
                }
                int userChoice = Int32.Parse(Console.ReadLine());
                MountCard(playerAttackCards[userChoice - 1]);
                Console.WriteLine();
                return true;
            }
            else
            {
                if (playerDefenseCards.Count > 0)
                {
                    Console.WriteLine("You are all out of attack cards. You must play a defense card now");
                    ChooseDefenseCard();
                }
                else 
                {
                    Console.WriteLine("You are all out of cards. Generating an attack card for you...");
                    MountCard(CardDealer.GenerateAttackCard(this));
                }
                return false;
            }
        }

        public virtual bool ChooseDefenseCard()
        {
            Console.WriteLine();
            if (playerDefenseCards.Count > 0)
            {
                Console.WriteLine("Please select a defense card to mount");
                for (int i = 0; i < playerDefenseCards.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + playerDefenseCards[i].Name + " - " + (playerDefenseCards[i].Defense * 100) + "% chance of deflect");
                }
                int userChoice = Int32.Parse(Console.ReadLine());
                MountCard(playerDefenseCards[userChoice - 1]);
                Console.WriteLine();
                return true;
            }
            else
            {
                if (playerAttackCards.Count > 0)
                {
                    Console.WriteLine("You are all out of defense cards. You must play an attack card now");
                    ChooseAttackCard();
                }
                else 
                {
                    Console.WriteLine("You are all out of cards. Generating a defense card for you...");
                    MountCard(CardDealer.GenerateDefenseCard(this));
                }
                return false;
            }
        }

        public virtual bool Attack(IMonsterable monster)
        {
            if (!monster.Defend(Strength))
            {
                Score += Strength;
                return true;
            }
            
            return false;
        }

        public virtual bool Defend(int monsterStrength)
        {
            // chance of the player defending successfully
            if (GenerateDefenseAbility() < Defense)
            {
                //Console.WriteLine("You deflect the monster's shot and sustain no damage.");
                return true;
            }
            else
            {
                Health -= monsterStrength;
                
                return false;
            }
        }

        protected virtual void PrintPlayerHealth()
        {
            Console.WriteLine("You have " + Health + " HP remaining");
        }

    }
}
