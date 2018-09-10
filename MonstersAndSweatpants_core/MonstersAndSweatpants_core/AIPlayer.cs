using System;

namespace Monsters_and_Sweatpants
{
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
            switch (new Random().Next(0, 2))
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
                throw new AIKilled();
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
