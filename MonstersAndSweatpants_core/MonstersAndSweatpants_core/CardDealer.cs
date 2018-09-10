using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public static class CardDealer
    {
        private static List<AttackCard> attackCards = new List<AttackCard>();
        private static List<DefenseCard> defenseCards = new List<DefenseCard>();

        public enum CardType
        {
            AttackCard, DefenseCard
        }

        static CardDealer()
        {
            StockDeck();
        }

        public static void StockDeck()
        {
            attackCards.Add(new LvlTenACard());
            attackCards.Add(new LvlNineACard());
            attackCards.Add(new LvlEightACard());
            attackCards.Add(new LvlSevenACard());
            attackCards.Add(new LvlSixACard());
            attackCards.Add(new LvlFiveACard());
            attackCards.Add(new LvlFourACard());
            attackCards.Add(new LvlThreeACard());
            attackCards.Add(new LvlTwoACard());
            attackCards.Add(new LvlOneACard());

            defenseCards.Add(new LvlTenDCard());
            defenseCards.Add(new LvlNineDCard());
            defenseCards.Add(new LvlEightDCard());
            defenseCards.Add(new LvlSevenDCard());
            defenseCards.Add(new LvlSixDCard());
            defenseCards.Add(new LvlFiveDCard());
            defenseCards.Add(new LvlFourDCard());
            defenseCards.Add(new LvlThreeDCard());
            defenseCards.Add(new LvlTwoDCard());
            defenseCards.Add(new LvlOneDCard());
        }

        public static void ResetDealer()
        {
            attackCards.Clear();
            defenseCards.Clear();
            StockDeck();
        }

        public static void GenerateCard(Player player, CardType cardType)
        {
            Random r = new Random();

            if (cardType == CardType.AttackCard)
            {
                int randomChoice = r.Next(0, attackCards.Count);
                player.playerAttackCards.Add(attackCards[randomChoice]);
                attackCards.RemoveAt(randomChoice);
                
            }
            else if (cardType == CardType.DefenseCard)
            {
                int randomChoice = r.Next(0, defenseCards.Count);
                player.playerDefenseCards.Add(defenseCards[randomChoice]);
                defenseCards.RemoveAt(randomChoice);
                
            }
            
        }

        public static AttackCard GenerateAttackCard(Player player)
        {
            Random r = new Random();
            StockDeck();
            int randomChoice = r.Next(0, attackCards.Count);
            return attackCards[randomChoice];

        }

        public static DefenseCard GenerateDefenseCard(Player player)
        {
            Random r = new Random();
            StockDeck();
            int randomChoice = r.Next(0, defenseCards.Count);
            return defenseCards[randomChoice];

        }
    }
}
