using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monsters_and_Sweatpants
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus.MainMenu();
        }

        public static void StartRounds(int roundCount)
        {
            if (roundCount == 1)
            {
                PlayGame();
            }
            else 
            {
                int roundsWon = 0;
                int roundsLost = 0;
                int halfway = (int)Math.Ceiling(roundCount / 2.0); // how many games player needs to win to be victorious

                for (int roundsPlayed = 0; roundsPlayed < roundCount; roundsPlayed++) 
                {
                    if (PlayGame() == true)
                    {
                        roundsWon++;
                    }
                    else 
                    {
                        roundsLost++;
                    }
                    if (roundsWon >= halfway)
                    {
                        Console.WriteLine("You won " + roundsWon + " rounds and are victorious!");
                        break;
                    }
                    if (roundsLost >= halfway)
                    {
                        Console.WriteLine("You lost " + roundsLost + " rounds and therefore have lost the whole game :(");
                        break;
                    }
                    CardDealer.ResetDealer(); // ensures the dealer starts fresh after each round
                }


            }
        }

        public static bool PlayGame()
        {
            int delayConstant = 0; // 1000 (1 sec) default, reduce for testing purposes
            UserPlayer userPlayer = new UserPlayer();
            AIPlayer computerPlayer = new AIPlayer();
            Console.WriteLine();
            Console.WriteLine("Ready to start? [y/n]");
            string userInput = Console.ReadLine();
            if (userInput.Equals("y"))
            {
                try
                {
                    IMonsterable m = MonsterGenerator.GenerateMonster();
                    while (userPlayer.Health > 0 && computerPlayer.Health > 0 && m.Health > 0)
                    {

                        userPlayer.UserPicksTypeOfCard();
                        Thread.Sleep(delayConstant);
                        computerPlayer.AIPicksTypeOfCard();
                        Thread.Sleep(delayConstant);
                        m.PickPlayerToAttack(userPlayer, computerPlayer);

                        Thread.Sleep(delayConstant);
                        userPlayer.Attack(m);
                        Thread.Sleep(delayConstant);
                        computerPlayer.Attack(m);
                        Thread.Sleep(delayConstant);

                        Menus.EndOfRoundStats(userPlayer, computerPlayer, m);

                    }

                }
                catch (UserDiedException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You lose!");
                    return false;
                }
                catch (AIDiedException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You win!");
                    return true;
                }
                catch (UserKilled)
                {
                    Console.WriteLine("You killed the monster! You win!");
                    return true;
                }
                catch (AIKilled)
                {
                    Console.WriteLine("Your opponent killed the monster! You lose!");
                    return false;
                }
                catch (Exception)
                {
                    Console.WriteLine("An unhandled exception occurred");
                    Thread.Sleep(delayConstant);
                    CardDealer.ResetDealer();
                    PlayGame();
                }
            }
            else 
            {
                Console.WriteLine("Sorry, this is not a game for quitters! ¯|_(ツ)_|¯");
                CardDealer.ResetDealer();
                PlayGame();
            }
            Console.ReadLine();
            return false;
        }
    }
}
