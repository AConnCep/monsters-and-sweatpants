using System;
using System.Collections.Generic;

namespace Monsters_and_Sweatpants
{
    class UserPlayer : Player
    {
        public new List<AttackCard> playerAttackCards = new List<AttackCard>();
        public new List<DefenseCard> playerDefenseCards = new List<DefenseCard>();

        private int playerHealth = 200;
        public override int Health
        {
            get
            {
                if (playerHealth <= 0)
                {
                    throw new UserDiedException();
                }
                return playerHealth;
            }
            set
            {
                playerHealth = value;
            }
        }

        public UserPlayer()
        {
            GeneratePlayerCards();
            Console.WriteLine();
            Console.WriteLine("These are the current cards you have: ");
            ReportCards(CardDealer.CardType.AttackCard);
            ReportCards(CardDealer.CardType.DefenseCard);
        }

        public override void MountCard(AttackCard card)
        {
            base.MountCard(card);
            Console.WriteLine("You have mounted " + card.Name + " with " + card.Attack + " HP of strength");
        }

        public override void MountCard(DefenseCard card)
        {
            base.MountCard(card);
            Console.WriteLine("You have mounted " + card.Name + " with " + (card.Defense * 100) + "% chance of deflect");
        }

        public override bool ChooseAttackCard()
        {
            if (!base.ChooseAttackCard())
            {
                //Console.WriteLine("You are all out of attack cards. Generating one for you...");
                return false;
            }
            return true;
        }

        public override bool ChooseDefenseCard()
        {
            if (!base.ChooseDefenseCard())
            {
                //Console.WriteLine("You are all out of defense cards. Generating one for you...");
                return false;
            }
            return true;
        }

        public void UserPicksTypeOfCard()
        {
            Console.WriteLine();
            Console.WriteLine("What type of card do you want to mount?");
            Console.WriteLine("1. Attack card");
            Console.WriteLine("2. Defense card");

            int userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    ChooseAttackCard();
                    break;
                case 2:
                    ChooseDefenseCard();
                    break;
            }
        }

        public override bool Attack(IMonsterable monster)
        {
            Console.WriteLine();
            Console.WriteLine("You are attacking the monster");
            try
            {
                if (base.Attack(monster))
                {
                    Console.WriteLine("You hit the monster! He loses " + Strength + " HP");
                    Console.WriteLine("You have been awarded " + Strength + " points");
                    return true;
                }
                Console.WriteLine("The monster deflects your shot and sustains no damage");
            }
            catch (MonsterDiedException)
            {
                throw new UserKilled();
            }
            return false;
        }

        public override bool Defend(int monsterStrength)
        {
            if (base.Defend(monsterStrength))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("You've successfully defended yourself against the monster!");
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You've been hit! You lose " + monsterStrength + " HP");
                Console.BackgroundColor = ConsoleColor.Black;
                PrintPlayerHealth();
                return false;
            }
        }
    }
}
