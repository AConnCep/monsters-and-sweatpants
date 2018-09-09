using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    static class MonsterGenerator
    {
        public static IMonsterable GenerateMonster()
        {
            Random r = new Random();
            int choice = r.Next(0, 4);
            Console.WriteLine();
            Console.WriteLine("~~~~GAME BEGIN~~~~");
            switch (choice)
            {
                case 0:                 
                    return new GoblinOfGoo();
                case 1:
                    return new TrollOfTribulation();
                case 2:
                    return new OrcOfOrdeal();
                case 3:
                    return new DragonOfDeath();
                // just to get the compiler to shut up
                default:
                    return null;
               
            }
        }
    }
}
