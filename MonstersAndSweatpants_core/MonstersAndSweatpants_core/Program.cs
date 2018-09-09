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
                }

            }
        }

        public static bool PlayGame()
        {
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
                        Thread.Sleep(1000);
                        computerPlayer.AIPicksTypeOfCard();
                        Thread.Sleep(1000);
                        m.PickPlayerToAttack(userPlayer, computerPlayer);

                        Thread.Sleep(1000);
                        userPlayer.Attack(m);
                        Thread.Sleep(1000);
                        computerPlayer.Attack(m);
                        Thread.Sleep(2000);

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
                //catch (MonsterDiedException e)
                //{
                //    Console.WriteLine(e.Message);
                //    if (userPlayer.Score > computerPlayer.Score)
                //    {
                //        Console.WriteLine("Your score of " + userPlayer.Score + " beats your opponent's score of " + computerPlayer.Score);
                //        Console.WriteLine("You win!");
                //    }
                //    else if (userPlayer.Score < computerPlayer.Score)
                //    {
                //        Console.WriteLine("Your opponent's score of " + computerPlayer.Score + " beats your score of " + userPlayer.Score);
                //        Console.WriteLine("You lose!");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Tie! You both have a score of " + userPlayer.Score);
                //    }
                //}
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
                    return false;
                }


            }
            else { Menus.ExitGame(); }
            Console.ReadLine();
            return false;
        }
    }
}
