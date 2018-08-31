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
        public double generateDefenseAbility() => r.NextDouble();

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
                Console.WriteLine("You are all out of attack cards. Generating one for you...");
                MountCard(CardDealer.GenerateAttackCard(this));
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
                Console.WriteLine("You are all out of defense cards. Generating one for you...");
                MountCard(CardDealer.GenerateDefenseCard(this));
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
            if (generateDefenseAbility() < Defense)
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
                Console.WriteLine("You've successfully defended yourself against the monster!");
                return true;
            }
            else
            {
                Console.WriteLine("You've been hit! You lose " + monsterStrength + " HP");
                PrintPlayerHealth();
                return false;
            }
        }
    }

    class AIPlayer : Player
    {
        private int AIHealth = 200;
        public override int Health
        {
            get
            {
                if (AIHealth <= 0)
                {
                    throw new AIDiedException();
                }
                return AIHealth;
            }
            set
            {
                AIHealth = value;
            }
        }

        public AIPlayer()
        {
            GenerateAICards();
            //ReportCards(CardDealer.CardType.DefenseCard);
        }

        public void GenerateAICards()
        {
            for (int i = 0; i < 5; i++)
            {
                CardDealer.GenerateCard(this, CardDealer.CardType.AttackCard);
                CardDealer.GenerateCard(this, CardDealer.CardType.DefenseCard);
            }
        }

        public override void MountCard(AttackCard card)
        {
            base.MountCard(card);
            Console.WriteLine("Your opponent has mounted " + card.Name + " with " + card.Attack + " HP of strength");
        }

        public override void MountCard(DefenseCard card)
        {
            base.MountCard(card);
            Console.WriteLine("Your opponent has mounted " + card.Name + " with " + (card.Defense * 100) + "% of deflect");
        }

        public override bool ChooseAttackCard()
        {
            if (playerAttackCards.Count > 0)
            {
                MountCard(playerAttackCards[r.Next(0, playerAttackCards.Count)]);
                return true;
            }
            else
            {
                Console.WriteLine("Your opponent is out of attack cards. Generating one...");
                MountCard(CardDealer.GenerateAttackCard(this));
                return false;
            }
        }

        public override bool ChooseDefenseCard()
        {
            if (playerDefenseCards.Count > 0)
            {
                MountCard(playerDefenseCards[r.Next(0, playerDefenseCards.Count)]);
                return true;
            }
            else
            {
                Console.WriteLine("Your opponent is out of defense cards. Generating one...");
                MountCard(CardDealer.GenerateDefenseCard(this));
                return false;
            }
        }

        public void AIPicksTypeOfCard()
        {
            switch (new Random().Next(0, 1))
            {
                case 0:
                    ChooseAttackCard();
                    break;
                case 1:
                    ChooseDefenseCard();
                    break;
            }
        }

        public override bool Defend(int monsterStrength)
        {
            if (base.Defend(monsterStrength))
            {
                Console.WriteLine("Your opponent successfully defended against the monster");
                return true;
            }
            else
            {
                Console.WriteLine("Your opponent was hit by the monster and loses " + monsterStrength + " HP");
                PrintPlayerHealth();
                return false;
            }
        }

        public override bool Attack(IMonsterable monster)
        {
            Console.WriteLine();
            Console.WriteLine("Your opponent is attacking the monster");
            try
            {
                if (base.Attack(monster))
                {
                    Console.WriteLine("Your opponent hit the monster! " + Strength + " points to them!");
                    monster.PrintMonsterHealth();
                    return true;
                }
            }
            catch (MonsterDiedException)
            {
                throw new UserKilled();
            }
            Console.WriteLine("Your opponent misses the monster");
            return false;
        }

        protected override void PrintPlayerHealth()
        {
            Console.WriteLine("Your opponent has " + Health + " HP remaining");
        }
    }
}
