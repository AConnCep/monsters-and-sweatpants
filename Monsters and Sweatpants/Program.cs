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

        public static void PlayGame()
        {
            UserPlayer userPlayer = new UserPlayer();
            AIPlayer computerPlayer = new AIPlayer();
            Console.WriteLine();
            try
            {
                Console.WriteLine("Ready to start? [y/n]");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
                }
                catch (AIDiedException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You win!");
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
                }
                catch (AIKilled)
                {
                    Console.WriteLine("Your opponent killed the monster! You lose!");
                }
                catch (Exception)
                {
                    Console.WriteLine("An unhandled exception occurred");
                }


            }
            else { Menus.ExitGame(); }
        }
    }
}
