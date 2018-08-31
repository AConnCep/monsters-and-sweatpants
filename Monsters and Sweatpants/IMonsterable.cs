using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters_and_Sweatpants
{
    public interface IMonsterable
    {
        int Health { get; set; }
        int Strength { get; set; }
        double Defense { get; set; }

        void PickPlayerToAttack(Player user, Player computer);

        void Attack(Player player);

        bool Defend(int playerStrength);

        void PrintMonsterHealth();

        void PrintMonsterStats();

        void DecreaseMonsterHealth(int playerStrength);

    }
}
