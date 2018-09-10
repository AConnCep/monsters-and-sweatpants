using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Monsters_and_Sweatpants
{
    static class Menus
    {
        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~MAIN MENU~~~~");
            Console.WriteLine("Welcome to Monsters and Sweatpants, a competitive co-op by Austin Cepalia");
            Console.WriteLine();
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. How to Play");
            Console.WriteLine("3. Attack Card Info");
            Console.WriteLine("4. Defense Card Info");
            Console.WriteLine("5. Monster Info");
            Console.WriteLine("6. Quit Game");
            Console.WriteLine();

            int userChoice = Int32.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    SelectNumberOfRounds();
                    break;
                case 2:
                    HowToPlay();
                    break;
                case 3:
                    AttackCardInfo();
                    break;
                case 4:
                    DefenseCardInfo();
                    break;
                case 5:
                    MonsterInfo();
                    break;
                case 6:
                    ExitGame();
                    break;
            }
        }

        public static void SelectNumberOfRounds()
        {
            Console.WriteLine("How many rounds would you like to play?");
            Console.WriteLine("1. Just one round");
            Console.WriteLine("2. Best out of three");
            Console.WriteLine("3. Best out of five");
            int userChoice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Onward!");
            Thread.Sleep(1000);
            switch (userChoice)
            {
                case 1:
                    Program.StartRounds(1);
                    break;

                case 2:
                    Program.StartRounds(3);
                    break;
                    
                case 3:
                    Program.StartRounds(5);
                    break;
            }

        }

        public static void HowToPlay()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~HOW TO PLAY~~~~");
            Console.WriteLine("In this game, you face your teammate in defeating a randomly-generated monster");
            Console.WriteLine("There are four monsters. Some are more powerful than others");
            Console.WriteLine("You are randomly assigned 5 attack cards and 5 defense cards. These cards give you your strength and defense abilities");
            Console.WriteLine("Before attacking the monster, you can mount one defense card or one attack card.");
            Console.WriteLine("Each point of health (HP) you deal on the monster earns you a point. This score has no effect on who wins/loses.");
            Console.WriteLine("Whichever player deals the final blow on the monster wins.");
            Console.WriteLine("If a player dies, they automatically lose.");
            AfterOtherMenus();

        }

        public static void AfterOtherMenus()
        {
            Console.WriteLine();
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1. Back to main menu");
            Console.WriteLine("2. Exit Game");

            int userChoice = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (userChoice)
            {
                case 1:
                    MainMenu();
                    break;
                case 2:
                    ExitGame();
                    break;
                case 3:
                    MainMenu();
                    break;
            }
        }

        public static void ExitGame() { }

        public static void AttackCardInfo()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~ATTACK CARDS~~~~");
            Console.WriteLine("The following cards can be mounted to give you various amounts of strength");
            Console.WriteLine();
            Console.WriteLine("Mega Godsent Strength: 10 HP");
            Console.WriteLine("The Big 9: 9 HP");
            Console.WriteLine("Strongboi: 8 HP");
            Console.WriteLine("Seven of Heaven: 7 HP");
            Console.WriteLine("Ok strength i guess: 6 HP");
            Console.WriteLine("Half Power: 5 HP");
            Console.WriteLine("Four Score: 4 HP");
            Console.WriteLine("Noodle-arm Ninny: 3 HP");
            Console.WriteLine("AMD CPU: 2 HP");
            Console.WriteLine("All Hands: 1 HP");
            AfterOtherMenus();
        }

        public static void DefenseCardInfo()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~DEFENSE CARDS~~~~");
            Console.WriteLine("The following cards can be mounted to give you various amounts of defense");
            Console.WriteLine();
            Console.WriteLine("Near-Invincibility: 95% chance of deflect");
            Console.WriteLine("Shield of Defense: 85% chance of deflect");
            Console.WriteLine("Heavyboi Armor: 80% chance of deflect");
            Console.WriteLine("No consent for u: 69% chance of deflect");
            Console.WriteLine("Middleman of Defense: 50% chance of deflect");
            Console.WriteLine("Better than Cardboard: 45% chance of deflect");
            Console.WriteLine("Literally Cardboard: 35% chance of deflect");
            Console.WriteLine("Rags and Robes: 30% chance of deflect");
            Console.WriteLine("Sweatpants: 20% chance of deflect");
            Console.WriteLine("Nakedman: 10% chance of deflect");
            AfterOtherMenus();
        }

        public static void MonsterInfo()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~MONSTERS~~~~");
            Console.WriteLine("Upon your quest you shall stumble upon one of these four monsters. Good luck");
            Console.WriteLine();
            Console.WriteLine("Goblin of Goo - 10 HP");
            Console.WriteLine("This entry-level monster will attack you with its goo, but it's not too difficult to kill");
            Console.WriteLine();
            Console.WriteLine("Troll of Tribulation - 25 HP");
            Console.WriteLine("Trolls don't only cross bridges...they also fist-fight players too...");
            Console.WriteLine();
            Console.WriteLine("Orc of Ordeal - 40 HP");
            Console.WriteLine("This orc may look easy, but he's more challenging than you think. Choose your cards wisely");
            Console.WriteLine();
            Console.WriteLine("Dragon of Death - 100 HP");
            Console.WriteLine("The hardest monster whose fire is capable of burning two warriors with ease. Avoid at all costs");
            AfterOtherMenus();
        }

        public static void EndOfRoundStats(UserPlayer user, AIPlayer computer, IMonsterable monster)
        {
            Console.WriteLine();
            Console.WriteLine("~~~~END OF ROUND STATISTICS~~~~");
            Console.WriteLine();
            Console.WriteLine("Your health: " + user.Health + " HP");
            Console.WriteLine("Your score: " + user.Score + " points");
            Console.WriteLine("Opponent's health: " + computer.Health + " HP");
            Console.WriteLine("Opponent's score: " + computer.Score + " points");
            Console.WriteLine("Monster's health: " + monster.Health + " HP");
        }
    }
}
